namespace Reservation.Domain.Repositories;


public interface ISmsTemplateRepository
{
    void Add(SmsTemplate smsTemplate);
    void Remove(SmsTemplate smsTemplate);
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken);
    Task<SmsTemplate> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<IResponse>> Gets(Guid businessId, CancellationToken cancellationToken);
}