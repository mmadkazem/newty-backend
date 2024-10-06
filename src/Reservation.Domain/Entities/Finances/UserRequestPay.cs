namespace Reservation.Domain.Entities.Finances;


public sealed class UserRequestPay : BaseClass<Guid>
{
    public int Amount { get; set; }
    public bool IsPay { get; set; } = false;
    public DateTime PayDate { get; set; }
    public string Authority { get; set; }
    public ulong RefId { get; set; }

    // Request Pay User
    public User User { get; set; }
    public Guid UserId { get; set; }
}