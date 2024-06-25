namespace Reservation.Application.Wallets.Queries.GetUserWallet;

public sealed class GetUserWalletQueryHandler(IUnitOfWork uow) : IRequestHandler<GetUserWalletQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetUserWalletQueryRequest request, CancellationToken cancellationToken)
        => await _uow.Wallets.GetUserWallet(request.UserId, cancellationToken)
            ?? throw new WalletNotFoundException();
}