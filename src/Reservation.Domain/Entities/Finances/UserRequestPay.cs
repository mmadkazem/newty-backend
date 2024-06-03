namespace Reservation.Domain.Entities.Finances;


public class UserRequestPay : BaseClass
{
    public int Price { get; set; }
    public bool IsPay { get; set; }
    public DateTime PayDate { get; set; }
    public string Authorizy { get; set; }
    public int RefId { get; set; }

    // Request Pay User
    public User User { get; set; }

    // Request Pay Reserve
    public ReserveTime ReserveTime { get; set; }
}