namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class BusinessRequestWithdrawRepository(NewtyDbContext context)
    : IBusinessRequestWithdrawRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(BusinessRequestWithdraw requestWithdraw)
        => _context.BusinessRequestWithdraws.Add(requestWithdraw);

    public async Task<BusinessRequestWithdraw> FindAsync(Guid id, CancellationToken token)
        => await _context.BusinessRequestWithdraws.AsQueryable()
                                                    .Where(b => b.Id == id)
                                                    .FirstOrDefaultAsync(token);

    public async Task<IEnumerable<IResponse>> GetAll(int page, int size, CancellationToken token)
        => await _context.BusinessRequestWithdraws.AsQueryable()
                                                    .Where(b => !b.IsWithdraw)
                                                    .OrderBy(b => b.CreatedOn)
                                                    .Select(b => new GetBusinessRequestWithdrawQueryResponse
                                                    (
                                                        b.Id,
                                                        b.BusinessId,
                                                        b.Business.CardNumber,
                                                        b.Amount
                                                    ))
                                                    .Skip((page - 1) * size)
                                                    .Take(size)
                                                    .ToListAsync(token);
}