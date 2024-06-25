using Reservation.Application.SmsTemplates.Queries.GetSmsTemplate;
using Reservation.Application.SmsTemplates.Queries.GetSmsTemplates;

namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class SmsTemplateRepository(ReservationDbContext context)
    : ISmsTemplateRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(SmsTemplate smsTemplate)
        => _context.SmsTemplates.Add(smsTemplate);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
        => await _context.SmsTemplates.AsQueryable()
                                        .AnyAsync(s => s.Name == name, cancellationToken);

    public async Task<SmsTemplate> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _context.SmsTemplates.AsQueryable()
                                        .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

    public async Task<IResponse> Get(Guid id, CancellationToken cancellationToken)
        => await _context.SmsTemplates.AsQueryable()
                                        .AsNoTracking()
                                        .Where(s => s.Id == id)
                                        .Select(s => new GetSmsTemplateQueryResponse
                                        (
                                            s.Id,
                                            s.Name,
                                            s.Description,
                                            s.Business.Id
                                        ))
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Gets(Guid businessId, CancellationToken cancellationToken)
        => await _context.SmsTemplates.AsQueryable()
                                        .AsNoTracking()
                                        .Where(s => s.Business.Id == businessId)
                                        .Select(s => new GetSmsTemplatesQueryResponse
                                        (
                                            s.Id,
                                            s.Name
                                        ))
                                        .ToListAsync(cancellationToken);
}