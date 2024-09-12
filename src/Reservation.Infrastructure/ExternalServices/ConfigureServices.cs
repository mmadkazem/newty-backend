namespace Reservation.Infrastructure.ExternalServices;

public static class ConfigureServices
{
        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
                // DI Services
                services.AddTransient<ICheckPaymentIsVerificationService, CheckPaymentIsVerificationService>();
                services.AddTransient<ITokenFactoryService, TokenFactoryService>();
                services.AddTransient<IUploadImageProvider, UploadImageProvider>();
                services.AddTransient<ISmsProvider, KavenegarProvider>();
                services.AddTransient<ICacheProvider, CacheProvider>();

                // DI Token Validators
                services.AddScoped<ITempTokenValidatorService, TempTokenValidatorService>();
                services.AddScoped<IBearerTokenValidatorService, BearerTokenValidatorService>();

                // DI Job
                services.AddSingleton<IPayingReserveTimeJob, PayingReserveTimeJob>();
                services.AddTransient<IFinishReserveTimeJob, FinishReserveTimeJob>();
                services.AddTransient<ISendSMSToUserVIPJob, SendSMSToUserVIPJob>();

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