namespace Reservation.Application.Wallets.Commands.FoundBusinessWallet;

public sealed class FoundBusinessWalletCommandHandler(IUnitOfWork uow)
        : IRequestHandler<FoundBusinessWalletCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(FoundBusinessWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var businessRequestPay = await _uow.BusinessRequestPays.FindAsync(request.RequestPayId, cancellationToken)
            ?? throw new BusinessRequestPayNotFoundException();

        var wallet = await _uow.Wallets.FindAsyncByBusinessId(businessRequestPay.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        businessRequestPay.Authorizy = request.Authorizy;
        businessRequestPay.RefId = request.RefId;
        businessRequestPay.ModifiedOn = DateTime.Now;

        wallet.Credit += request.Credit;
        wallet.ModifiedOn = DateTime.Now;
        wallet.Transactions.Add(new() { Amount = request.Credit, Type = TransactionType.Charge });

        await _uow.SaveChangeAsync(cancellationToken);
    }
}