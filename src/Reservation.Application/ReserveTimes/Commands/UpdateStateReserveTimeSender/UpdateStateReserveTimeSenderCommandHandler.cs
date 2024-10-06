namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTimeSender;

public sealed class UpdateStateReserveTimeSenderCommandHandler(IUnitOfWork uow, IFinishReserveTimeJob finishReserveTimeJob)
    : IRequestHandler<UpdateStateReserveTimeSenderCommandRequest, UpdateStateReserveTimeSenderCommandResponse>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IFinishReserveTimeJob _finishReserveTimeJob = finishReserveTimeJob;

    public async Task<UpdateStateReserveTimeSenderCommandResponse> Handle(UpdateStateReserveTimeSenderCommandRequest request, CancellationToken cancellationToken)
    {
        var reserveTime = await _uow.ReserveTimes.FindAsyncIncludeTransaction(request.Id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();

        var reserveTimeSender = await _uow.ReserveTimes.FindAsyncReserveTimeSender(request.Id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();

        if (reserveTime.BusinessSenderId != request.BusinessId &&
            reserveTime.BusinessReceiptId != request.BusinessId)
        {
            throw new DotAccessReserveTimeException();
        }

        if (request.State == ReserveState.Cancelled)
        {
            if (DateTime.Now.AddDays(1) >= reserveTime.TotalStartDate)
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
            reserveTime.Finished = true;
            reserveTime.ModifiedOn = DateTime.Now;

            reserveTimeSender.State = ReserveState.Cancelled;
            reserveTimeSender.Finished = true;
            reserveTimeSender.ModifiedOn = DateTime.Now;

            await _uow.SaveChangeAsync(cancellationToken);

            return new(ReserveTimeSuccessMessage.UpdatedCancelState);
        }

        if (request.State == ReserveState.Confirmed)
        {
            if (reserveTime.BusinessSenderId == request.BusinessId)
            {
                throw new BusinessNotAccessStateIsConfirmedException();
            }

            var businessSenderWallet = await _uow.Wallets.FindAsyncByUserId(reserveTime.BusinessSender.Id, cancellationToken)
                ?? throw new WalletNotFoundException();

            var businessReceiptWallet = await _uow.Wallets.FindAsyncByBusinessId(reserveTime.BusinessReceiptId, cancellationToken)
                ?? throw new WalletNotFoundException();

            // Deduct from the user wallet
            if (businessSenderWallet.Credit - reserveTime.TransactionSender.Amount < 0)
            {
                throw new BalanceInsufficientException();
            }
            businessSenderWallet.Credit -= reserveTime.TransactionSender.Amount;

            // Transfer to business wallet
            businessReceiptWallet.Credit += reserveTime.TransactionReceipt.Amount;

            // Final record of time
            reserveTime.State = ReserveState.Confirmed;
            reserveTime.TransactionReceipt.State = TransactionState.Confirmed;
            reserveTime.TransactionSender.State = TransactionState.Confirmed;
            reserveTime.ModifiedOn = DateTime.Now;

            reserveTimeSender.State = ReserveState.Confirmed;
            reserveTimeSender.ModifiedOn = DateTime.Now;

            await _uow.SaveChangeAsync(cancellationToken);
            _finishReserveTimeJob.Execute(reserveTime.Id, reserveTime.TotalEndDate.AddMinutes(2));

            return new(ReserveTimeSuccessMessage.UpdatedConfirmState);
        }

        return new();
    }
}