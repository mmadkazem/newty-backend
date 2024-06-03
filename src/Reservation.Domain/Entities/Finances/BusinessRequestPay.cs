namespace Reservation.Domain.Entities.Finances;


public class BusinessRequestPay : BaseClass
{
    public int Price { get; set; }
    public bool IsPay { get; set; }
    public DateTime PayDate { get; set; }
    public string Authorizy { get; set; }
    public int RefId { get; set; }

    // Request Pay Business
    public Business Business { get; set; }
}