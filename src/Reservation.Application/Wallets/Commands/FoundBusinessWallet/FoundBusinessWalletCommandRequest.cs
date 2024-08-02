namespace Reservation.Application.Wallets.Commands.FoundBusinessWallet;


public record FoundBusinessWalletCommandRequest(decimal Credit, Guid RequestPayId, string Authorizy, int RefId)
    : IRequest;
