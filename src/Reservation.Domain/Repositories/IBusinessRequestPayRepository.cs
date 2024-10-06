namespace Reservation.Domain.Repositories;


public interface IBusinessRequestPayRepository
{
    void Add(BusinessRequestPay businessRequestPay);
    void Remove(BusinessRequestPay businessRequestPay);
    Task<BusinessRequestPay> FindAsync(Guid id, string authorizy, CancellationToken cancellationToken = default);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<IResponse>> GetByBusinessId(int page, int size, Guid businessId, CancellationToken cancellationToken);
}