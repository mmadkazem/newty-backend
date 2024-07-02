namespace Reservation.Infrastructure.ExternalServices;

public static class ConfigureServices
{
        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
                // DI Services
                services.AddTransient<ITokenFactoryService, TokenFactoryService>();
                services.AddTransient<IUploadImageProvider, UploadImageProvider>();
                services.AddTransient<ISmsProvider, KavenegarProvider>();
                services.AddTransient<ICacheProvider, CacheProvider>();

                // DI Token Validators
                services.AddScoped<IBusinessTokenValidatorService, BusinessTokenValidatorService>();
                services.AddScoped<ITempTokenValidatorService, TempTokenValidatorService>();
                services.AddScoped<IUserTokenValidatorService, UserTokenValidatorService>();

                // DI Options
                services.AddOptions<TempTokenOption>()
                        .Bind(configuration.GetSection("TempToken"));

                services.AddOptions<UserTokenOption>()
                        .Bind(configuration.GetSection("UserToken"));

                services.AddOptions<BusinessTokenOption>()
                        .Bind(configuration.GetSection("BusinessToken"));

                services.AddOptions<RefreshTokenOption>()
                        .Bind(configuration.GetSection("RefreshToken"));

                services.AddOptions<AdminTokenOption>()
                        .Bind(configuration.GetSection("AdminToken"));

                services.AddOptions<SmsProviderOption>()
                        .Bind(configuration.GetSection("SmsProvider"));

                // DI Redis Cache
                services.AddStackExchangeRedisCache(options =>
                        options.Configuration = configuration.GetConnectionString("Redis"));

                return services;
        }
}