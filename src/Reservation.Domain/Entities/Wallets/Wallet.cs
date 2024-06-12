namespace Reservation.Domain.Entities.Wallets;

public class Wallet : BaseClass
{
    public int Credit { get; set; }

    // User Wallet
    public User User { get; set; }
    public Guid UserId { get; set; }

    // Wallet Transactions
    public ICollection<Transaction> Transactions { get; set; }
}
