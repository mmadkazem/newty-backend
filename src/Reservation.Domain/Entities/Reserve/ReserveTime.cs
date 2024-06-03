namespace Reservation.Domain.Entities.Reserve;


public class ReserveTime : BaseClass
{
    public DateTime TotalStartDate { get; set; }
    public DateTime TotalEndDate { get; set; }
    public int TotalPrice { get; set; }
    public bool Finished { get; set; }

    // User Reserve Time
    public User User { get; set; }

    // Business Reserve Time
    public Business Business { get; set; }

    // Reserve Item
    public ICollection<ReserveItem> ReserveItems { get; set; }
}