namespace Reservation.Infrastructure.Persistance;


public static class ConfigureServices
{
    public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DI Repositories
        services.AddTransient<IBusinessRepository, BusinessRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        // DI UnitOfWork
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        // DI DbContext
        services.AddDbContext<ReservationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ReservationDb")));
        return services;
    }
}