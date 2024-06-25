namespace Reservation.Application.Wallets.Commands.FoundUserWallet;


public record FoundUserWalletCommandRequest(Guid UserId, decimal Credit) : IRequest
{
    public static FoundUserWalletCommandRequest Create(Guid id, decimal credit)
        => new(id, credit);
}
