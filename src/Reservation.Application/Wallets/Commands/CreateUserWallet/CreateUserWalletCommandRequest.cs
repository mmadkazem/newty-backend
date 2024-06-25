namespace Reservation.Application.Wallets.Commands.CreateUserWallet;


public record CreateUserWalletCommandRequest(Guid UserId) : IRequest;
