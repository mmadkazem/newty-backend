namespace Reservation.Application.Wallets.Queries.GetBusinessWallet;

public sealed class GetBusinessWalletQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetBusinessWalletQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetBusinessWalletQueryRequest request, CancellationToken cancellationToken)
        => await _uow.Wallets.GetBusinessWallet(request.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();
}