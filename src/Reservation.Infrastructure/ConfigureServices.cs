
using Reservation.Infrastructure.ExternalServices;

namespace Liaro.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPersistanceServices(configuration)
                .RegisterExternalServices(configuration);

        return services;
    }
}