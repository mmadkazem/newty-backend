namespace Reservation.Domain.Entities.Reserve;


public class ReserveItem : BaseClass
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Price { get; set; }
    public bool Finished { get; set; }

    // Reserve Service
    public Service Service { get; set; }
}