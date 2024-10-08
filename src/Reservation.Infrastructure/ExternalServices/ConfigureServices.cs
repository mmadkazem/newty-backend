using Reservation.Infrastructure.ExternalServices.Payments.Options;
using Zarinpal.AspNetCore.Consts;
using Zarinpal.AspNetCore.Extensions;

namespace Reservation.Infrastructure.ExternalServices;

public static class ConfigureServices
{
        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
                // DI Services
                services.AddScoped<ITokenFactoryService, TokenFactoryService>();
                services.AddScoped<IObjectStorageProvider, ObjectStorageProvider>();
                services.AddScoped<IPaymentProvider, PaymentProvider>();
                services.AddScoped<ISmsProvider, KavenegarProvider>();
                services.AddScoped<ICacheProvider, CacheProvider>();

                // DI Token Validators
                services.AddScoped<ITempTokenValidatorService, TempTokenValidatorService>();
                services.AddScoped<IBearerTokenValidatorService, BearerTokenValidatorService>();

                // DI Job
                services.AddSingleton<IPayingReserveTimeJob, PayingReserveTimeJob>();
                services.AddScoped<IFinishReserveTimeJob, FinishReserveTimeJob>();
                services.AddScoped<ISendSMSToUserVIPJob, SendSMSToUserVIPJob>();
                services.AddScoped<PayingReserveTimeExecution>();
                services.AddScoped<FinishReserveTimeService>();

                // DI Options
                services.Configure<TokenOption>(configuration);

                // DI Redis Cache
                services.AddStackExchangeRedisCache(options =>
                        options.Configuration = configuration.GetConnectionString("Redis"));

                #region DI Hangfire
#pragma warning disable CS0618 // Type or member is obsolete
                services.AddHangfire
                (
                        c => c.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                .UseSimpleAssemblyNameTypeSerializer()
                                .UseRecommendedSerializerSettings()
                                .UsePostgreSqlStorage(configuration.GetConnectionString("JobConnection"))
                );
                services.AddHangfireServer();
#pragma warning restore CS0618 // Type or member is obsolete
                #endregion

                // DI Zarinpal
                services.Configure<ZarinpalOption>(configuration);
                services.Configure<PaymentUrlOption>(configuration);
                var zarinpalOption = configuration.GetSection("ZarinpalOption").Get<ZarinpalOption>()!;
                services.AddZarinpal(options =>
                {
                        options.MerchantId = zarinpalOption.MerchantId;
                        options.ZarinpalMode = ZarinpalMode.Sandbox;
                        options.Currency = ZarinpalCurrency.IRT;
                });

                services.AddScoped<IPaymentUrlGeneratorService, PaymentUrlGeneratorService>();

                return services;
        }
        public static WebApplication UseJob(this WebApplication app)
        {
                app.UseHangfireDashboard("/job/dashboard", new DashboardOptions()
                {
                        Authorization = [new AuthorizationDashboard()],
                        IsReadOnlyFunc = (context) => true
                });

                app.UseEndpoints(endpoints =>
                {
                        var unused1 = endpoints.MapControllers();
                        var unused = endpoints.MapHangfireDashboard();
                });

                var payingReserveTimeJob = app.Services.GetService<IPayingReserveTimeJob>();
                payingReserveTimeJob.Execute();

                return app;
        }
}