namespace Reservation.Domain.Entities.Businesses;


public class BusinessService : BaseClass<Guid>
{
    public string Name { get; set; }
    public TimeOnly Time { get; set; }
    public int Price { get; set; }
    public bool Active { get; set; } = true;

    // Business Service
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }

    // Artist
    public Artist Artist { get; set; }

    // Service Coupons
    public ICollection<Coupon> Coupons { get; set; }

}