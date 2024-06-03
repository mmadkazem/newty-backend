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

public class Transaction : BaseClass
{
    public int Amount { get; set; }
    public string Description { get; set; } = null!;

    // Wallet Transaction
    public Wallet Wallet { get; set; }

    // Transaction for Reserve Time
    public ReserveTime ReserveTime { get; set; }
}