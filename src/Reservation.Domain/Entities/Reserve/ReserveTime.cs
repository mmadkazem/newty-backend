namespace Reservation.Domain.Entities.Reserve;


public class ReserveTimeOut : BaseClass
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

public class ReserveTimeIn : BaseClass
{
    public DateTime TotalStartDate { get; set; }
    public DateTime TotalEndDate { get; set; }
    public int TotalPrice { get; set; }
    public ReserveState State { get; set; }
    public bool Finished { get; set; } = false;

    // Business Reserve Time In
    public Business BusinessIn { get; set; }
    public Guid BusinessInId { get; set; }

    // Business Reserve Time Out
    public Business BusinessOut { get; set; }
    public Guid BusinessOutId { get; set; }

    // Reserve Item
    public ICollection<ReserveItem> ReserveItems { get; set; }
}