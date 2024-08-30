

namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class SmsCreditRepository(NewtyDbContext context, NewtyDbContextCommand contextCommand)
    : ISmsCreditRepository
{
    private readonly NewtyDbContext _context = context;
    private readonly NewtyDbContextCommand _contextCommand = contextCommand;

    public void Add(SmsCredit smsCredit)
        => _contextCommand.SmsCredits.Add(smsCredit);

    public async Task<SmsCredit> FindAsync(Guid businessId, CancellationToken cancellationToken)
        => await _contextCommand.SmsCredits.AsQueryable()
                                        .FirstOrDefaultAsync(b => b.BusinessId == businessId, cancellationToken);
}