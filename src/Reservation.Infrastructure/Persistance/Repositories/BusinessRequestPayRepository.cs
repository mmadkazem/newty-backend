namespace Reservation.Infrastructure.Persistance.Repositories;

public sealed class BusinessRequestPayRepository(NewtyDbContext context, NewtyDbContextCommand contextCommand)
    : IBusinessRequestPayRepository
{
    private readonly NewtyDbContext _context = context;
    private readonly NewtyDbContextCommand _contextCommand = contextCommand;

    public void Add(BusinessRequestPay businessRequestPay)
        => _contextCommand.BusinessRequestPays.Add(businessRequestPay);

    public void Remove(BusinessRequestPay businessRequestPay)
        => _contextCommand.BusinessRequestPays.Remove(businessRequestPay);

    public async Task<BusinessRequestPay> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _contextCommand.BusinessRequestPays.AsQueryable()
                                                .FirstOrDefaultAsync(r => r.Id == id && !r.IsPay, cancellationToken);

    public async Task<IResponse> Get(Guid id, CancellationToken cancellationToken)
        => await _context.BusinessRequestPays.AsQueryable()
                                .AsNoTracking()
                                .Where(b => b.Id == id)
                                .Select(b => new GetBusinessRequestPayQueryResponse
                                (
                                    b.Id,
                                    b.PayDate,
                                    b.IsPay,
                                    b.Amount,
                                    b.Authorizy,
                                    b.RefId
                                ))
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetByBusinessId(int page, int size, Guid businessId, CancellationToken cancellationToken)
        => await _context.BusinessRequestPays.AsQueryable()
                                .AsNoTracking()
                                .Where(b => b.BusinessId == businessId)
                                .Select(b => new GetBusinessRequestPaysQueryResponse
                                (
                                    b.Id,
                                    b.PayDate,
                                    b.IsPay,
                                    b.Amount
                                ))
                                .Skip((page - 1) * size)
                                .Take(size)
                                .ToListAsync(cancellationToken);

}