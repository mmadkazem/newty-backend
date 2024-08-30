namespace Reservation.Domain.Repositories;



public interface IServiceRepository
{
    void Add(BusinessService service);
    void Remove(BusinessService service);
    Task<BusinessService> FindAsync(Guid serviceId, CancellationToken cancellationToken = default);
    Task<BusinessService> FindAsyncIncludeArtist(Guid serviceId, CancellationToken cancellationToken);
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetArtistServices(Guid artistId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetServiceByBusinessId(int page, int size, Guid businessId, CancellationToken cancellationToken = default);
}