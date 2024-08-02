namespace Reservation.Application.Wallets.Commands.FoundUserWallet;


public record FoundUserWalletCommandRequest(decimal Credit, Guid RequestPayId, string Authorizy, int RefId)
    : IRequest;