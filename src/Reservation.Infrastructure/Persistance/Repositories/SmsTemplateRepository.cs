namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class SmsTemplateRepository(NewtyDbContext context, NewtyDbContextCommand contextCommand)
    : ISmsTemplateRepository
{
    private readonly NewtyDbContext _context = context;
    private readonly NewtyDbContextCommand _contextCommand = contextCommand;

    public void Add(SmsTemplate smsTemplate)
        => _contextCommand.SmsTemplates.Add(smsTemplate);

    public void Remove(SmsTemplate smsTemplate)
        => _contextCommand.SmsTemplates.Remove(smsTemplate);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
        => await _contextCommand.SmsTemplates.AsQueryable()
                                        .AnyAsync(s => s.Name == name, cancellationToken);

    public async Task<SmsTemplate> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _contextCommand.SmsTemplates.AsQueryable()
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