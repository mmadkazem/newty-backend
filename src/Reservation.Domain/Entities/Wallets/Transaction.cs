namespace Reservation.Domain.Entities.Wallets;

public class Transaction : BaseClass
{
    public int Amount { get; set; }
    public string Description { get; set; } = null!;

    // Wallet Transaction
    public Wallet Wallet { get; set; }

    // Transaction for Reserve Time
    public ReserveTimeOut ReserveTime { get; set; }
}