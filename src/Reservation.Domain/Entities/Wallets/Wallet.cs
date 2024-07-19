namespace Reservation.Domain.Entities.Wallets;

public class Wallet : BaseClass
{
    public decimal Credit { get; set; }
    public decimal BlockCredit { get; set; }

    // Wallet Transactions
    public ICollection<Transaction> Transactions { get; set; } = [];
}
