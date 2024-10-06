namespace Reservation.Application.Wallets.Commands.FoundUserWallet;


public sealed record FoundUserWalletCommandRequest(Guid RequestPayId, string Authorizy)
    : IRequest<string>;