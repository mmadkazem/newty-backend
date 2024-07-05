namespace Reservation.Application.Wallets.Commands.WithdrawBusinessWallet;


public record WithdrawBusinessWalletCommandRequest(Guid BusinessId, decimal Amount) : IRequest
{
    public static WithdrawBusinessWalletCommandRequest Create(Guid businessId, decimal amount)
        => new(businessId, amount);
}
