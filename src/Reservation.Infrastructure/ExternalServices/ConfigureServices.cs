using Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators;

namespace Reservation.Infrastructure.ExternalServices;

public static class ConfigureServices
{
        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
                // DI Services
                services.AddScoped<ITempTokenValidatorService, TempTokenValidatorService>();
                services.AddTransient<ITokenFactoryService, TokenFactoryService>();
                services.AddTransient<IUploadImageProvider, UploadImageProvider>();
                services.AddTransient<ISmsProvider, KavenegarProvider>();
                services.AddTransient<ICacheProvider, CacheProvider>();
                // DI Options
                services.AddOptions<TempTokenOption>()
                        .Bind(configuration.GetSection("TempToken"));

                services.AddOptions<UserTokenOption>()
                        .Bind(configuration.GetSection("UserToken"));

                services.AddOptions<BusinessTokenOption>()
                        .Bind(configuration.GetSection("BusinessToken"));

                services.AddOptions<RefreshTokenOption>()
                        .Bind(configuration.GetSection("RefreshToken"));

                services.AddOptions<SmsProviderOption>()
                        .Bind(configuration.GetSection("SmsProvider"));

                services.AddStackExchangeRedisCache(options =>
                        options.Configuration = configuration.GetConnectionString("Redis"));

                return services;
        }
}