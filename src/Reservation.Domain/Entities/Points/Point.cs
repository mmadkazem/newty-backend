namespace Reservation.Domain.Entities.Points;

public class Point : BaseClass
{
    public int Rate { get; set; }

    // User For Rate
    public User User { get; set; }

    // Business For Rate
    public Business Business { get; set; }
}