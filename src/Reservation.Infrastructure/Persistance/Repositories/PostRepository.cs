namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class PostRepository(NewtyDbContext context, NewtyDbContextCommand contextCommand) : IPostRepository
{
    private readonly NewtyDbContext _context = context;
    private readonly NewtyDbContextCommand _contextCommand = contextCommand;

    public void Add(Post post)
        => _contextCommand.Posts.Add(post);

    public void Remove(Post post)
        => _contextCommand.Posts.Remove(post);

    public async Task<bool> AnyAsync(string title, CancellationToken cancellationToken)
        => await _contextCommand.Posts.AsQueryable()
                                .AnyAsync(b => b.Title == title, cancellationToken);

    public async Task<Post> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _contextCommand.Posts.AsQueryable()
                                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

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

    public async Task<IEnumerable<IResponse>> GetPosts(int page, int size, Guid businessId, CancellationToken cancellationToken)
        => await _context.Posts.AsQueryable()
                                .AsNoTracking()
                                .Where(p => p.BusinessId == businessId)
                                .Select(p => new GetPostsQueryResponse
                                (
                                    p.Id,
                                    p.Title,
                                    p.CoverImagePath
                                ))
                                .Skip((page - 1) * size)
                                .Take(size)
                                .ToListAsync(cancellationToken);

}