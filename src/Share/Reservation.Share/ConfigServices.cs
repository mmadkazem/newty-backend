namespace Reservation.Share;
public static class ConfigServices
{
    public static IServiceCollection RegisterSharedServices(this IServiceCollection services)
    {
        services.AddScoped<ValidationsExceptionMiddleware>();
        services.AddScoped<UnAuthorizeExceptionMiddleware>();
        services.AddScoped<BadRequestExceptionMiddleware>();
        services.AddScoped<ForbiddenExceptionMiddleware>();
        services.AddScoped<NotFoundExceptionMiddleware>();
        return services;
    }
    public static IApplicationBuilder UseShared(this IApplicationBuilder app)
    {
        app.UseMiddleware<ValidationsExceptionMiddleware>();
        app.UseMiddleware<UnAuthorizeExceptionMiddleware>();
        app.UseMiddleware<BadRequestExceptionMiddleware>();
        app.UseMiddleware<ForbiddenExceptionMiddleware>();
        app.UseMiddleware<NotFoundExceptionMiddleware>();
        return app;
    }
}