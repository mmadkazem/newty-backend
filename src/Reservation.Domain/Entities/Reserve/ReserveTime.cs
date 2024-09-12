namespace Reservation.Domain.Entities.Reserve;


public class ReserveTimeReceipt : BaseClass<Guid>
{
    public DateTime TotalStartDate { get; set; }
    public DateTime TotalEndDate { get; set; }
    public int TotalPrice { get; set; }
    public ReserveState State { get; set; }
    public bool Finished { get; set; } = false;
    public bool IsPay { get; set; } = false;

    // Business Receipt Reserve Time
    public Business BusinessReceipt { get; set; }
    public Guid BusinessReceiptId { get; set; }

    // User Reserve Time
    public User User { get; set; }
    public Guid? UserId { get; set; }

    // Business Sender Reserve Time
    public Business BusinessSender { get; set; }
    public Guid? BusinessSenderId { get; set; }

    // Transactions
    public Transaction TransactionSender { get; set; }
    public Guid TransactionSenderId { get; set; }

    public Transaction TransactionReceipt { get; set; }
    public Guid TransactionReceiptId { get; set; }

    // Reserve Item
    public ICollection<ReserveItem> ReserveItems { get; set; }
}

public class ReserveTimeSender : BaseClass<Guid>
{
    public DateTime TotalStartDate { get; set; }
    public DateTime TotalEndDate { get; set; }
    public int TotalPrice { get; set; }
    public ReserveState State { get; set; }
    public bool Finished { get; set; } = false;
    public bool IsPay { get; set; } = false;

    // Business Reserve Time In
    public Business BusinessSender { get; set; }
    public Guid BusinessSenderId { get; set; }

    // Business Reserve Time Out
    public Business BusinessReceipt { get; set; }
    public Guid BusinessReceiptId { get; set; }

    // Reserve Item
    public ICollection<ReserveItem> ReserveItems { get; set; }
}