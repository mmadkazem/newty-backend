namespace Reservation.Domain.Entities.Businesses;


public class UserVIP : BaseClass
{
    public User User { get; set; }
    public Business Business { get; set; }
}