namespace Reservation.Domain.Entities.Reserve;

public class ReserveItem : BaseClass<Guid>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Price { get; set; }
    public bool Finished { get; set; } = false;

    // Reserve Service
    public BusinessService Service { get; set; }
    public Guid ServiceId { get; set; }
}