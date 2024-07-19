namespace Reservation.Domain.Entities.Businesses;

public class SmsTemplate : BaseClass
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Business Sms Template
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }
}