namespace Reservation.Domain.Repositories;


public interface IPostRepository
{
    void Add(Post post);
    Task<bool> AnyAsync(string title, CancellationToken cancellationToken = default);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetPosts(int page, Guid businessId, CancellationToken cancellationToken = default);
}