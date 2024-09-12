namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTime;

public sealed class UpdateStateReserveTimeReceiptCommandHandler(IUnitOfWork uow, IFinishReserveTimeJob finishReserveTimeJob)
    : IRequestHandler<UpdateStateReserveTimeReceiptCommandRequest, UpdateStateReserveTimeReceiptCommandResponse>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IFinishReserveTimeJob _finishReserveTimeJob = finishReserveTimeJob;

    public async Task<UpdateStateReserveTimeReceiptCommandResponse> Handle(UpdateStateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        var reserveTime = await _uow.ReserveTimes.FindAsyncIncludeTransaction(request.Id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();

        if ((reserveTime.User.Id != request.CallId && Role.User == request.Role) ||
            (reserveTime.BusinessReceipt.Id != request.CallId && Role.Business == request.Role))
        {
            throw new DotAccessReserveTimeException();
        }

        if (request.State == ReserveState.Cancelled)
        {
            if (DateTime.Now.AddDays(1).Day <= reserveTime.TotalStartDate.Day)
            {
                throw new TimePassedCannotCancelException();
            }

            if (!reserveTime.BusinessReceipt.IsCancelReserveTime)
            {
                throw new BusinessCannotBeCanceledException();
            }

            reserveTime.State = ReserveState.Cancelled;
            reserveTime.TransactionReceipt.State = TransactionState.Cancelled;
            reserveTime.TransactionSender.State = TransactionState.Cancelled;
            reserveTime.ModifiedOn = DateTime.Now;

            await _uow.SaveChangeAsync(cancellationToken);

            return new(ReserveTimeSuccessMessage.UpdatedCancelState);
        }

        if (request.State == ReserveState.Confirmed)
        {
            if (request.Role == Role.User)
            {
                throw new UserNotAccessStateIsConfirmedException();
            }

            var userWallet = await _uow.Wallets.FindAsyncByUserId(reserveTime.User.Id, cancellationToken)
                ?? throw new WalletNotFoundException();

            var businessWallet = await _uow.Wallets.FindAsyncByBusinessId(reserveTime.BusinessReceiptId, cancellationToken)
                ?? throw new WalletNotFoundException();

            // Deduct from the user wallet
            if (userWallet.Credit - reserveTime.TransactionReceipt.Amount < 0)
            {
                throw new BalanceInsufficientException();
            }
            userWallet.Credit -= reserveTime.TransactionReceipt.Amount;

            // Transfer to business wallet
            businessWallet.Credit += reserveTime.TransactionReceipt.Amount;

            // Final record of time
            reserveTime.State = ReserveState.Confirmed;
            reserveTime.TransactionReceipt.State = TransactionState.Confirmed;
            reserveTime.TransactionSender.State = TransactionState.Confirmed;
            reserveTime.ModifiedOn = DateTime.Now;

            await _uow.SaveChangeAsync(cancellationToken);
            _finishReserveTimeJob.Execute(reserveTime.Id, reserveTime.TotalEndDate.AddMinutes(2));
            return new(ReserveTimeSuccessMessage.UpdatedConfirmState);
        }
        return new();

    }

}