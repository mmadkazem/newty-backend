using Reservation.Application.ExternalServices.Job;
using Reservation.Infrastructure.ExternalServices;

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
    var payingReserveTimeJob = app.Services.GetService<IPayingReserveTimeJob>();
    payingReserveTimeJob.Execute();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseShared();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseJob();

    app.Run();
}