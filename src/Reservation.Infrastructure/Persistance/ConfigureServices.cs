using Reservation.Infrastructure.Persistance.SeedData.TestData;

namespace Reservation.Infrastructure.Persistance;


public static class ConfigureServices
{
    public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DI Repositories
        services.AddTransient<IBusinessRequestPayRepository, BusinessRequestPayRepository>();
        services.AddTransient<IUserRequestPayRepository, UserRequestPayRepository>();
        services.AddTransient<ITransferFeeRepository, TransferFeeRepository>();
        services.AddTransient<ISmsTemplateRepository, SmsTemplateRepository>();
        services.AddTransient<IReserveTimeRepository, ReserveTimeRepository>();
        services.AddTransient<ISmsCreditRepository, SmsCreditRepository>();
        services.AddTransient<IBusinessRepository, BusinessRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddTransient<ISmsPlanRepository, SmsPlanRepository>();
        services.AddTransient<IArtistRepository, ArtistRepository>();
        services.AddTransient<IWalletRepository, WalletRepository>();
        services.AddTransient<ICouponRepository, CouponRepository>();
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IPostRepository, PostRepository>();


        // DI UnitOfWork
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        // DI DbContext
        services.AddDbContext<NewtyDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("NewtyDb")), ServiceLifetime.Transient);

        // DI Seeding Data
        services.AddSingleton<ICategorySeedData, CategorySeedData>();
        services.AddSingleton<ISeedTestDataService, SeedTestDataService>();
        services.AddTransient<IReadCategoryInJsonService, ReadCategoryInJsonService>();

        return services;
    }

    public static WebApplication UseSeedingData(this WebApplication app)
    {
        // var seedDataCategory = app.Services.GetService<ICategorySeedData>();
        // seedDataCategory.SeedData();
        // var seedTestData = app.Services.GetService<ISeedTestDataService>();
        // seedTestData.SeedData();
        return app;
    }
}