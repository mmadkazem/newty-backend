

namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class SmsCreditRepository(ReservationDbContext context)
    : ISmsCreditRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(SmsCredit smsCredit)
        => _context.SmsCredits.Add(smsCredit);

    public async Task<SmsCredit> FindAsync(Guid businessId, CancellationToken cancellationToken)
        => await _context.SmsCredits.AsQueryable()
                                    .FirstOrDefaultAsync(b => b.BusinessId == businessId, cancellationToken);
}