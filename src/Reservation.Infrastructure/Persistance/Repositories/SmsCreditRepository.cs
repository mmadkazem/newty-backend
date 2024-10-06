namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class SmsCreditRepository(NewtyDbContext context)
    : ISmsCreditRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(SmsCredit smsCredit)
        => _context.SmsCredits.Add(smsCredit);

    public async Task<SmsCredit> FindAsync(Guid businessId, CancellationToken cancellationToken)
        => await _context.SmsCredits.AsQueryable()
                                    .Include(s => s.Business)
                                    .FirstOrDefaultAsync(b => b.BusinessId == businessId, cancellationToken);

    public async Task<IResponse> Get(Guid businessId, CancellationToken cancellationToken)
        => await _context.SmsCredits.AsQueryable()
                                    .Where(s => s.BusinessId == businessId)
                                    .Select(s => new GetSmsCreditQueryResponse(s.SmsCount))
                                    .FirstOrDefaultAsync(cancellationToken);
}