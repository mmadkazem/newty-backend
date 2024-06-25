namespace Reservation.Domain.Repositories;



public interface IServiceRepository
{
    void Add(Service service);
    Task<Service> FindAsync(Guid serviceId, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetArtistServices(Guid artistId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetServiceByBusinessId(int page, Guid businessId, CancellationToken cancellationToken = default);
}