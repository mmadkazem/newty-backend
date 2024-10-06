namespace Reservation.Infrastructure.ExternalServices.Job;


public sealed class FinishReserveTimeJob(IBackgroundJobClient client)
    : IFinishReserveTimeJob
{
    private readonly IBackgroundJobClient _client = client;

    public void Execute(Guid reserveTimeId, DateTime date)
    {
        _client.Schedule<FinishReserveTimeService>(s => s.Execute(reserveTimeId), date);
    }
}

public sealed class FinishReserveTimeService(NewtyDbContext context)
{
    private readonly NewtyDbContext _context = context;

    public void Execute(Guid reserveTimeId)
    {
        _context.ReserveTimesReceipt.Where(t => t.Id == reserveTimeId)
                                    .ExecuteUpdateAsync(s => s.SetProperty(r => r.Finished, true));
    }
}