namespace Reservation.Application.Wallets.Commands.CreateBusinessWallet;


public record CreateBusinessWalletCommandRequest(Guid BusinessId) : IRequest;


public sealed class CreateBusinessWalletCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateBusinessWalletCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateBusinessWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();
        business.Wallet = new();

        await _uow.SaveChangeAsync(cancellationToken);
    }
}