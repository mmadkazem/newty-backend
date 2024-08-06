namespace Reservation.Application.Wallets.Commands.FoundBusinessWallet;


public record FoundBusinessWalletCommandRequest(Guid RequestPayId, string Authorizy)
    : IRequest;
