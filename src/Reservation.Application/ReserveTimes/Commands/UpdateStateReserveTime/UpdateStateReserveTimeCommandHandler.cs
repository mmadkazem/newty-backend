namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTime;

public sealed class UpdateStateReserveTimeReceiptCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateStateReserveTimeReceiptCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateStateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        var reserveTime = await _uow.ReserveTimes.FindAsyncIncludeTransaction(request.Id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();

        if (request.State == ReserveState.Cancelled)
        {
            reserveTime.Finished = true;
            reserveTime.State = ReserveState.Cancelled;
            reserveTime.TransactionReceipt.State = TransactionState.Cancelled;
            reserveTime.TransactionSender.State = TransactionState.Cancelled;
            reserveTime.ModifiedOn = DateTime.Now;

            await _uow.SaveChangeAsync(cancellationToken);

            return;
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
            reserveTime.Finished = true;
            reserveTime.State = ReserveState.Confirmed;
            reserveTime.TransactionReceipt.State = TransactionState.Confirmed;
            reserveTime.TransactionSender.State = TransactionState.Confirmed;
            reserveTime.ModifiedOn = DateTime.Now;

            await _uow.SaveChangeAsync(cancellationToken);

            return;
        }
    }

}