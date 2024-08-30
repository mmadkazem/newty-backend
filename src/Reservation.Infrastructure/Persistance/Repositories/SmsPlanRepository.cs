namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class SmsPlanRepository(NewtyDbContext context, NewtyDbContextCommand contextCommand) : ISmsPlanRepository
{
    private readonly NewtyDbContext _context = context;
    private readonly NewtyDbContextCommand _contextCommand = contextCommand;

    public void Add(SmsPlan smsPlan)
        => _contextCommand.SmsPlans.Add(smsPlan);

    public void Remove(SmsPlan smsPlan)
        => _contextCommand.SmsPlans.Remove(smsPlan);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
        => await _contextCommand.SmsPlans.AsQueryable()
                                .AnyAsync(s => s.Name == name, cancellationToken);

    public async Task<SmsPlan> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _contextCommand.SmsPlans.AsQueryable()
                                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

    public async Task<IEnumerable<IResponse>> Get(int page, int size, CancellationToken cancellationToken = default)
        => await _context.SmsPlans.AsQueryable()
                                .AsNoTracking()
                                .OrderBy(s => s.Price)
                                .Select(s => new GetSmsPlansQueryResponse
                                (
                                    s.Id,
                                    s.Name,
                                    s.Description,
                                    s.SmsCount,
                                    s.Price,
                                    s.CoverImagePath,
                                    s.Discount
                                ))
                                .Skip((page - 1) * size)
                                .Take(size)
                                .ToListAsync(cancellationToken);
}