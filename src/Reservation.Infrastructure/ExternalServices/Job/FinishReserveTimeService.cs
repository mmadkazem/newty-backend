namespace Reservation.Infrastructure.ExternalServices.Job;


public sealed class FinishReserveTimeJob(IBackgroundJobClient client) : IFinishReserveTimeJob
{
    private readonly IBackgroundJobClient _client = client;

    public void Execute(Guid reserveTimeId, DateTimeOffset date)
    {
        _client.Schedule<FinishReserveTimeService>(s => s.Execute(reserveTimeId), date);
    }
}

public sealed class FinishReserveTimeService(IServiceScopeFactory scopeFactory)
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

    public async Task Execute(Guid reserveTimeId)
    {
        using var serviceScope = _scopeFactory.CreateScope();
        using var _context = serviceScope.ServiceProvider.GetService<ReservationDbContext>();

        var reserveTime = await _context.ReserveTimesReceipt
                            .AsQueryable()
                            .FirstOrDefaultAsync(r => r.Id == reserveTimeId);

        reserveTime.Finished = true;

        await _context.SaveChangesAsync();
    }
}