namespace Reservation.Domain.Repositories;


public interface IArtistRepository
{
    void Add(Artist artist);
    Task<Artist> FindAsync(Guid artistId, CancellationToken cancellationToken = default);
    Task<IResponse> Get(Guid artistId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetArtistByBusinessId(Guid businessId, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Guid artistId, CancellationToken cancellationToken = default);
    Task<Artist> FindAsyncByIncludePoints(Guid artistId, CancellationToken cancellationToken);
}