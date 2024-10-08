namespace Reservation.Domain.Entities.Wallets;

public class Wallet : BaseClass<Guid>
{
    public decimal Credit { get; set; }
    public decimal BlockCredit { get; set; }
    public decimal BlockCreditInWithdraw { get; set; }

    // Wallet Transactions
    public ICollection<Transaction> Transactions { get; set; } = [];
}
