namespace Reservation.Infrastructure.ExternalServices.Job;


public sealed class FinishReserveTimeJob(IBackgroundJobClient client, IConfiguration configuration)
    : IFinishReserveTimeJob
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBackgroundJobClient _client = client;

    public void Execute(Guid reserveTimeId, DateTimeOffset date)
    {
        _client.Schedule<FinishReserveTimeService>(s => s.Execute(reserveTimeId, _configuration), date);
    }
}

public sealed class FinishReserveTimeService
{

    public void Execute(Guid reserveTimeId, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("NewtyDb");
        var option = new DbContextOptionsBuilder<NewtyDbContext>()
                            .UseNpgsql(connectionString)
                            .Options;

        using NewtyDbContext _context = new(option);

        _context.ReserveTimesReceipt.Where(t => t.Id == reserveTimeId)
                                    .ExecuteUpdateAsync(s => s.SetProperty(r => r.Finished, true));
    }
}