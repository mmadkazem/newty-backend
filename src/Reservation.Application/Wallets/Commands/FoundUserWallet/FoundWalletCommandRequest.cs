namespace Reservation.Application.Wallets.Commands.FoundUserWallet;


public record FoundUserWalletCommandRequest(Guid RequestPayId, string Authorizy)
    : IRequest;