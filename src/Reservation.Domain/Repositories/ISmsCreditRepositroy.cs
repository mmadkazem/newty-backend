namespace Reservation.Domain.Repositories;


public interface ISmsCreditRepository
{
    void Add(SmsCredit smsCredit);
    Task<SmsCredit> FindAsync(Guid businessId, CancellationToken cancellationToken);
    Task<IResponse> Get(Guid businessId, CancellationToken cancellationToken);
}