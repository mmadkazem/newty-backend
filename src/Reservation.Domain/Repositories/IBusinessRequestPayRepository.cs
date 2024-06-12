
namespace Reservation.Domain.Repositories;


public interface IBusinessRequestPayRepository
{
    void Add(BusinessRequestPay businessRequestPay);
    Task<BusinessRequestPay> FindAsync(Guid id, CancellationToken cancellationToken = default);
}