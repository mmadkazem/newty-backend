namespace Reservation.Domain.Entities.Finances;


public class BusinessRequestPay : BaseClass
{
    public int Amount { get; set; }
    public bool IsPay { get; set; } = false;
    public DateTime PayDate { get; set; }
    public string Authorizy { get; set; } = null!;
    public int RefId { get; set; }

    // Request Pay Business
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }
}