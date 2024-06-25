
namespace Reservation.Infrastructure.Persistance.Repositories;

public sealed class BusinessRequestPayRepository(ReservationDbContext context)
    : IBusinessRequestPayRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(BusinessRequestPay businessRequestPay)
        => _context.BusinessRequestPays.Add(businessRequestPay);

    public async Task<BusinessRequestPay> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _context.BusinessRequestPays.AsQueryable()
                                                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

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

    public async Task<IEnumerable<IResponse>> GetByBusinessId(int page, Guid businessId, CancellationToken cancellationToken)
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
                                .Skip((page - 1) * 25)
                                .Take(25)
                                .ToListAsync(cancellationToken);
}