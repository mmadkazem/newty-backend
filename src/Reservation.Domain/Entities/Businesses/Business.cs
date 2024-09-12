namespace Reservation.Domain.Entities.Businesses;


public class Business : BaseClass<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public string CoverImagePath { get; set; }
    public string ParvaneKasbImagePath { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public bool IsCancelReserveTime { get; set; }
    public bool IsClose { get; set; }
    public TimeSpan StartHoursOfWor { get; set; }
    public TimeSpan EndHoursOfWor { get; set; }
    public List<DayOfWeek> Holidays { get; set; } = [];
    public BusinessState State { get; set; }

    // Business Wallet
    public Wallet Wallet { get; set; }

    // User VIP and Normal User
    public ICollection<UserVIP> UsersVIP { get; set; }
    public ICollection<User> UsersNormal { get; set; }

    // Sms Credit for Send sms
    public virtual SmsCredit SmsCredit { get; set; }
    public Guid SmsCreditId { get; set; }

    // Business Point
    public ICollection<Point> Points { get; set; } = [];

    // Business Services
    public ICollection<BusinessService> Services { get; set; }

    // Business Artists
    public ICollection<Artist> Artists { get; set; }

    // Business City
    public City City { get; set; }
    public int CityId { get; set; }

    // Business Post
    public ICollection<Post> Posts { get; set; }

    // Business Template
    public ICollection<SmsTemplate> SmsTemplates { get; set; }

    // Business Reserve Time
    public ICollection<ReserveTimeSender> ReserveTimesSender { get; set; }
    public ICollection<ReserveTimeReceipt> ReserveTimesReceipt { get; set; }

    // Business Category
    public ICollection<Category> Categories { get; set; } = [];
}


public enum BusinessState
{
    Waiting,
    InValid,
    Valid
}