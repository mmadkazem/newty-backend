namespace Reservation.Domain.Entities.Wallets;

public class Transaction : BaseClass<Guid>
{
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public TransactionState State { get; set; }

    // Wallet Transaction
    public Wallet Wallet { get; set; }
    public Guid WalletId { get; set; }

}

public enum TransactionType
{
    Withdraw = 0,
    Charge = 1,
    ReserveTimeSender = 2,
    ReserveTimeReceipt = 3
}

public enum TransactionState
{
    Waiting = 0,
    Confirmed = 1,
    Cancelled = 2
}