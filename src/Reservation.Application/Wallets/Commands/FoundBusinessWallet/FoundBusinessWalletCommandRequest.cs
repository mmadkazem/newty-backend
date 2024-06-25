namespace Reservation.Application.Wallets.Commands.FoundBusinessWallet;


public record FoundBusinessWalletCommandRequest(Guid BusinessId, decimal Credit) : IRequest
{
    public static FoundBusinessWalletCommandRequest Create(Guid businessId, decimal credit)
        => new(businessId, credit);
}


public sealed class FoundBusinessWalletCommandHandler(IUnitOfWork uow)
        : IRequestHandler<FoundBusinessWalletCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(FoundBusinessWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var wallet = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        wallet.Credit = request.Credit;
        wallet.ModifiedOn = DateTime.Now;
        wallet.Transactions.Add(new() {Amount = request.Credit, Type = TransactionType.Charge});

        await _uow.SaveChangeAsync(cancellationToken);
    }
}