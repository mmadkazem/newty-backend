namespace Reservation.Application.Wallets.Commands.WithdrawUserWallet;


public record WithdrawUserWalletCommandRequest(Guid UserId, decimal Amount) : IRequest
{
    public static WithdrawUserWalletCommandRequest Create(Guid userId, decimal amount)
        => new(userId, amount);
}