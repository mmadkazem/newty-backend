namespace Reservation.Domain.Entities.Businesses;

public sealed class DiscountCode : BaseClass
{
    public string Code { get; set; }
    public DateTime Expire { get; set; }

    // Business Discount Code
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }
}