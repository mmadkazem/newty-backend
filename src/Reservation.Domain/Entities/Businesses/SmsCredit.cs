namespace Reservation.Domain.Entities.Businesses;


public class SmsCredit : BaseClass<Guid>
{
    public int SmsCount { get; set; }

    // Business Rel
    public virtual Business Business { get; set; }
    public Guid BusinessId { get; set; }
}