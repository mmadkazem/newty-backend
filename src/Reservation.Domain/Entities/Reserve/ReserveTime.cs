namespace Reservation.Domain.Entities.Reserve;


public class ReserveTimeReceipt : BaseClass
{
    public DateTime TotalStartDate { get; set; }
    public DateTime TotalEndDate { get; set; }
    public int TotalPrice { get; set; }
    public ReserveState State { get; set; }
    public bool Finished { get; set; } = false;

    // User Reserve Time
    public User User { get; set; }
    public Guid UserId { get; set; }

    // Business Reserve Time
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }

    // Reserve Item
    public ICollection<ReserveItem> ReserveItems { get; set; }
}

public class ReserveTimeSender : BaseClass
{
    public DateTime TotalStartDate { get; set; }
    public DateTime TotalEndDate { get; set; }
    public int TotalPrice { get; set; }
    public ReserveState State { get; set; }
    public bool Finished { get; set; } = false;

    // Business Reserve Time In
    public Business BusinessSender { get; set; }
    public Guid BusinessSenderId { get; set; }

    // Business Reserve Time Out
    public Business BusinessReceipt { get; set; }
    public Guid BusinessReceiptId { get; set; }

    // Reserve Item
    public ICollection<ReserveItem> ReserveItems { get; set; }
}