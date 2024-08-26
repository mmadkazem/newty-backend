namespace Reservation.Domain.Entities.Businesses;


public class Post : BaseClass<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImagePath { get; set; }

    // Business Post
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }
}