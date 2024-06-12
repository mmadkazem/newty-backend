namespace Reservation.Domain.Entities.Businesses;


public class Business : BaseClass
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CoverImagePath { get; set; }
    public string ParvaneKasbImagePath { get; set; }
    public string Address { get; set; }
    public bool Active { get; set; } = true;
    public string PhoneNumber { get; set; }

    // User VIP and Normal User
    public ICollection<UserVIP> UsersVIP { get; set; }
    public ICollection<User> UsersNormal { get; set; }

    // Sms Credit for Send sms
    public virtual SmsCredit SmsCredit { get; set; }
    public Guid SmsCreditId { get; set; }

    // Business Point
    public ICollection<Point> Points { get; set; }

    // Business Services
    public ICollection<Service> Services { get; set; }

    // Business Artists
    public ICollection<Artist> Artists { get; set; }

    // Business City
    public City City { get; set; }
    public Guid CityId { get; set; }

    // Business Post
    public ICollection<Post> Posts { get; set; }

    // Business Template
    public ICollection<SmsTemplate> SmsTemplates { get; set; }

    // Business Reserve Time
    public ICollection<ReserveTimeIn> ReserveTimesIn { get; set; }
    public ICollection<ReserveTimeOut> ReserveTimesOut { get; set; }
}