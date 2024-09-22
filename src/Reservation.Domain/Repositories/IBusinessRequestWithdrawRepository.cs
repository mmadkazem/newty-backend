namespace Reservation.Domain.Repositories;


public interface IBusinessRequestWithdrawRepository
{
    void Add(BusinessRequestWithdraw requestWithdraw);
    Task<BusinessRequestWithdraw> FindAsync(Guid id, CancellationToken token);
    Task<IEnumerable<IResponse>> GetAll(int page, int size, CancellationToken token);
}