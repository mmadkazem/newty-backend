namespace Reservation.Domain.Repositories;


public interface ICityRepository
{
    void Add(City city);
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default);
    Task<City> FindAsyncByName(string name, CancellationToken cancellationToken = default);
    Task<City> FindAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetAll(CancellationToken cancellationToken);
    Task<IResponse> Get(Guid Id, CancellationToken cancellationToken);
}