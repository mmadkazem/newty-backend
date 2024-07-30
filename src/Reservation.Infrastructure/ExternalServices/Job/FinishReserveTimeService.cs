namespace Reservation.Infrastructure.ExternalServices.Job;


public sealed class FinishReserveTimeJob(IBackgroundJobClient client, IServiceScopeFactory scopeFactory)
    : IFinishReserveTimeJob
{
    private readonly IBackgroundJobClient _client = client;
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;


    public void Execute(Guid reserveTimeId, DateTimeOffset date)
    {
        _client.Schedule<FinishReserveTimeService>(s => s.Execute(reserveTimeId, _scopeFactory), date);
    }
}

public sealed class FinishReserveTimeService
{

    public void Execute(Guid reserveTimeId, IServiceScopeFactory _scopeFactory)
    {
        using var serviceScope = _scopeFactory.CreateScope();
        using var _context = serviceScope.ServiceProvider.GetService<ReservationDbContext>();

        var reserveTime = _context.ReserveTimesReceipt.AsQueryable()
                                        .FirstOrDefault(r => r.Id == reserveTimeId);

        reserveTime.Finished = true;

        _context.SaveChanges();
    }
}