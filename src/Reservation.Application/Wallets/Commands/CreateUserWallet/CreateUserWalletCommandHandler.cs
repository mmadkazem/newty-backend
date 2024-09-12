namespace Reservation.Application.Wallets.Commands.CreateUserWallet;

public sealed class CreateUserWalletCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateUserWalletCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateUserWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();

        user.Wallet = new();

        await _uow.SaveChangeAsync(cancellationToken);
    }
}