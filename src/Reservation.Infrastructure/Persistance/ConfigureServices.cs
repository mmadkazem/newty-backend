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
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IPostRepository, PostRepository>();


        // DI UnitOfWork
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        // DI DbContext
        services.AddDbContext<ReservationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("NewtyDb")));

        return services;
    }
}