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
    // if (app.Environment.IsDevelopment())
    // {
        app.UseSwagger();
        app.UseSwaggerUI();
    // }

    app.UseHttpsRedirection();
    app.UseShared();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}