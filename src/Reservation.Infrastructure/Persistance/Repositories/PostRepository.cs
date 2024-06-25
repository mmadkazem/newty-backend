

namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class PostRepository(ReservationDbContext context) : IPostRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(Post post)
        => _context.Posts.Add(post);

    public async Task<bool> AnyAsync(string title, CancellationToken cancellationToken)
        => await _context.Posts.AsQueryable()
                                .AnyAsync(b => b.Title == title, cancellationToken);

    public async Task<IResponse> Get(Guid id, CancellationToken cancellationToken)
        => await _context.Posts.AsQueryable()
                                .AsNoTracking()
                                .Where(p => p.Id == id)
                                .Select(p => new GetPostQueryResponse
                                (
                                    p.Id,
                                    p.Title,
                                    p.Description,
                                    p.CoverImagePath
                                ))
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetPosts(int page, Guid businessId, CancellationToken cancellationToken)
        => await _context.Posts.AsQueryable()
                                .AsNoTracking()
                                .Where(p => p.BusinessId == businessId)
                                .Select(p => new GetPostsQueryResponse
                                (
                                    p.Id,
                                    p.Title,
                                    p.CoverImagePath
                                ))
                                .Skip((page - 1) * 25)
                                .Take(25)
                                .ToListAsync(cancellationToken);
}