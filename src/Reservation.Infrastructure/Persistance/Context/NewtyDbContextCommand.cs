// namespace Reservation.Infrastructure.Persistance.Context;



// public sealed class NewtyDbContextReadOnly : DbContext
// {
//     public NewtyDbContextReadOnly(DbContextOptions<NewtyDbContextReadOnly> options) : base(options)
//     {
//         AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//     }

//     public IQueryable<User> GetUsers() => Set<User>().AsQueryable();

//     // Business
//     public IQueryable<Business> GetBusinesses() => Set<Business>().AsQueryable();
//     public IQueryable<BusinessService> GetServices() => Set<BusinessService>().AsQueryable();
//     public IQueryable<Artist> GetArtists() => Set<Artist>().AsQueryable();
//     public IQueryable<Post> GetPosts() => Set<Post>().AsQueryable();
//     public IQueryable<UserVIP> GetUsersVIP() => Set<UserVIP>().AsQueryable();
//     public IQueryable<SmsCredit> GetSmsCredits() => Set<SmsCredit>().AsQueryable();
//     public IQueryable<SmsTemplate> GetSmsTemplates() => Set<SmsTemplate>().AsQueryable();

//     // Reserve
//     public IQueryable<ReserveTimeReceipt> GetReserveTimesReceipt() => Set<ReserveTimeReceipt>().AsQueryable();
//     public IQueryable<ReserveTimeSender> GetReserveTimesSender() => Set<ReserveTimeSender>().AsQueryable();
//     public IQueryable<ReserveItem> GetReserveItems() => Set<ReserveItem>().AsQueryable();

//     // Category
//     public IQueryable<Category> GetCategories() => Set<Category>().AsQueryable();

//     // Point
//     public IQueryable<Point> GetPoints() => Set<Point>().AsQueryable();

//     // City
//     public IQueryable<City> GetCities() => Set<City>().AsQueryable();

//     // Finance
//     public IQueryable<BusinessRequestPay> GetBusinessRequestPays() => Set<BusinessRequestPay>().AsQueryable();
//     public IQueryable<UserRequestPay> GetUserRequestPays() => Set<UserRequestPay>().AsQueryable();

//     // Wallet
//     public IQueryable<Wallet> GetWallets() => Set<Wallet>().AsQueryable();
//     public IQueryable<Transaction> GetTransactions() => Set<Transaction>().AsQueryable();

//     // SmsPlan
//     public IQueryable<SmsPlan> GetSmsPlans() => Set<SmsPlan>().AsQueryable();

//     // FeeTransfer
//     public IQueryable<TransferFee> GetTransferFees() => Set<TransferFee>().AsQueryable();

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//         base.OnConfiguring(optionsBuilder);
//         optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
//     }
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         base.OnModelCreating(modelBuilder);

//         modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
//         modelBuilder.ConfigSoftDeleteFilter();
//     }
// }