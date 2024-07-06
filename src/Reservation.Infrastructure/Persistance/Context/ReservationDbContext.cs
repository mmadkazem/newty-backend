using Reservation.Infrastructure.Persistance.Interceptor;

namespace Reservation.Infrastructure.Persistance.Context;

public sealed class ReservationDbContext : DbContext
{
    public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    // User
    public DbSet<User> Users { get; set; }

    // Business
    public DbSet<Business> Businesses { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<UserVIP> UsersVIP { get; set; }
    public DbSet<SmsCredit> SmsCredits { get; set; }
    public DbSet<SmsTemplate> SmsTemplates { get; set; }

    // Reserve
    public DbSet<ReserveTimeReceipt> ReserveTimesReceipt { get; set; }
    public DbSet<ReserveTimeSender> ReserveTimesSender { get; set; }
    public DbSet<ReserveItem> ReserveItems { get; set; }

    // Category
    public DbSet<Category> Categories { get; set; }

    // Point
    public DbSet<Point> Points { get; set; }

    // City
    public DbSet<City> Cities { get; set; }

    // Finance
    public DbSet<BusinessRequestPay> BusinessRequestPays { get; set; }
    public DbSet<UserRequestPay> UserRequestPays { get; set; }

    // Wallet
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}