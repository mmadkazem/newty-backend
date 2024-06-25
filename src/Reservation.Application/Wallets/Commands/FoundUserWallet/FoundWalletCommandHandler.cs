namespace Reservation.Application.Wallets.Commands.FoundUserWallet;

public sealed class FoundUserWalletCommandHandler(IUnitOfWork uow)
    : IRequestHandler<FoundUserWalletCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(FoundUserWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var wallet = await _uow.Wallets.FindAsyncByUserId(request.UserId, cancellationToken)
            ?? throw new WalletNotFoundException();

        wallet.Credit = request.Credit;
        wallet.ModifiedOn = DateTime.Now;
        wallet.Transactions.Add(new() {Amount = request.Credit, Type = TransactionType.Charge});

        await _uow.SaveChangeAsync(cancellationToken);
    }
}