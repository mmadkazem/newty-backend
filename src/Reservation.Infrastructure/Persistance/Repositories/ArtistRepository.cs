namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class ArtistRepository(NewtyDbContext context) : IArtistRepository
{
    private readonly NewtyDbContext _context = context;
    public void Add(Artist artist)
        => _context.Artists.Add(artist);

    public void Remove(Artist artist)
        => _context.Artists.Remove(artist);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default)
        => await _context.Artists.AsQueryable()
                                    .AnyAsync(b => b.Name == name, cancellationToken);

    public async Task<bool> AnyAsync(Guid artistId, CancellationToken cancellationToken = default)
        => await _context.Artists.AsQueryable()
                                    .AnyAsync(b => b.Id == artistId, cancellationToken);

    public async Task<Artist> FindAsync(Guid artistId, CancellationToken cancellationToken)
        => await _context.Artists.AsQueryable()
                                    .Include(a => a.Business)
                                    .Where(b => b.Id == artistId)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Artist> FindAsyncByIncludePoints(Guid artistId, CancellationToken cancellationToken)
        => await _context.Artists.AsQueryable()
                                    .Include(a => a.Points)
                                    .Where(b => b.Id == artistId)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> Get(Guid artistId, CancellationToken cancellationToken = default)
        => await _context.Artists.AsQueryable()
                                    .Where(c => c.Id == artistId)
                                    .Select(c => new GetArtistQueryResponse
                                    (
                                        c.Id,
                                        c.Name,
                                        c.Description,
                                        c.CoverImagePath,
                                        c.Active
                                    ))
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetArtistByBusinessId(Guid businessId, CancellationToken cancellationToken)
        => await _context.Artists.AsQueryable()
                                    .AsSplitQuery()
                                    .Where(c => c.BusinessId == businessId)
                                    .Select(s => new GetArtistByBusinessIdQueryResponse
                                    (
                                        s.Id,
                                        s.Name,
                                        s.CoverImagePath,
                                        s.Active
                                    )
                                    ).ToListAsync(cancellationToken);

}