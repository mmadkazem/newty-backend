namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class SmsPlanRepository(NewtyDbContext context) : ISmsPlanRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(SmsPlan smsPlan)
        => _context.SmsPlans.Add(smsPlan);

    public void Remove(SmsPlan smsPlan)
        => _context.SmsPlans.Remove(smsPlan);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
        => await _context.SmsPlans.AsQueryable()
                                .AnyAsync(s => s.Name == name, cancellationToken);

    public async Task<SmsPlan> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _context.SmsPlans.AsQueryable()
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