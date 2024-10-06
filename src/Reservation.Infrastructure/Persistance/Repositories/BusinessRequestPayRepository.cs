namespace Reservation.Infrastructure.Persistance.Repositories;

public sealed class BusinessRequestPayRepository(NewtyDbContext context)
    : IBusinessRequestPayRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(BusinessRequestPay businessRequestPay)
        => _context.BusinessRequestPays.Add(businessRequestPay);

    public void Remove(BusinessRequestPay businessRequestPay)
        => _context.BusinessRequestPays.Remove(businessRequestPay);

    public async Task<BusinessRequestPay> FindAsync(Guid id, string authorizy, CancellationToken cancellationToken)
        => await _context.BusinessRequestPays.AsQueryable()
                                .Include(b => b.Business)
                                .Where(r => r.Id == id && r.Authorizy == authorizy && !r.IsPay)
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> Get(Guid id, CancellationToken cancellationToken)
        => await _context.BusinessRequestPays.AsQueryable()
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