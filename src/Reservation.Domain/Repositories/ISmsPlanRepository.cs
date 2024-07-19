namespace Reservation.Domain.Repositories;


public interface ISmsPlanRepository
{
    void Add(SmsPlan smsPlan);
    void Remove(SmsPlan smsPlan);
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default);
    Task<SmsPlan> FindAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> Get(int page, CancellationToken cancellationToken = default);
}