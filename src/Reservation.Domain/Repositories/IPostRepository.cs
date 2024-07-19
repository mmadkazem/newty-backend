namespace Reservation.Domain.Repositories;


public interface IPostRepository
{
    void Add(Post post);
    void Remove(Post post);
    Task<bool> AnyAsync(string title, CancellationToken cancellationToken = default);
    Task<Post> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetPosts(int page, Guid businessId, CancellationToken cancellationToken = default);
}