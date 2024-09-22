namespace Reservation.Application.Wallets.Commands.WithdrawBusinessWallet;

public sealed class WithdrawBusinessWalletCommandHandler(IUnitOfWork uow) : IRequestHandler<WithdrawBusinessWalletCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(WithdrawBusinessWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var wallet = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        if (wallet.Credit - request.Amount < 0)
        {
            throw new BalanceInsufficientException();
        }
        if (wallet.BlockCreditInWithdraw > 0)
        {
            throw new RequestWithdrawIsExistException();
        }

        wallet.Credit -= request.Amount;
        wallet.BlockCreditInWithdraw += request.Amount;
        // wallet.Transactions.Add(new() { Amount = request.Amount, Type = TransactionType.Withdraw});
        BusinessRequestWithdraw requestWithdraw = new()
        {
            BusinessId = request.BusinessId,
            Amount = request.Amount
        };
        _uow.BusinessRequestWithdraws.Add(requestWithdraw);

        await _uow.SaveChangeAsync(cancellationToken);
    }
}