namespace Reservation.Domain.Entities.Businesses;

public sealed class Coupon : BaseClass
{
    public string Code { get; set; }
    public DateTime Expire { get; set; }

    // Business Discount Code
    public BusinessService Service { get; set; }
    public Guid ServiceId { get; set; }
}