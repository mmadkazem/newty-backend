namespace Reservation.Domain.Repositories;


public interface IBusinessRequestPayRepository
{
    void Add(BusinessRequestPay businessRequestPay);
    void Remove(BusinessRequestPay businessRequestPay);
    Task<BusinessRequestPay> FindAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<IResponse>> GetByBusinessId(int page, Guid businessId, CancellationToken cancellationToken);
}