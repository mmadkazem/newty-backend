using Reservation.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container
var services = builder.Services;
{
    services
        .RegisterApplicationServices()
        .RegisterInfrastructureServices(configuration)
        .RegisterSharedServices()
        .RegisterApiServices(configuration);
}


// Configure the HTTP request pipeline
var app = builder.Build();
{
    app.UseSeedingData();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseShared();


    app.UseAuthentication();
    app.UseAuthorization();

    app.UseJob();

    app.Run();
}