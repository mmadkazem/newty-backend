namespace Reservation.Domain.Entities.Businesses;


public class Artist : BaseClass
{
    public string Name { get; set; }
    public string CoverImagePath { get; set; }
    public bool Active { get; set; } = true;
    public string Description { get; set; }

    // Business Artist
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }

    // Artist Point
    public ICollection<Point> Points { get; set; } = [];

    // Artist Services
    public ICollection<Service> Services { get; set; } = [];

}