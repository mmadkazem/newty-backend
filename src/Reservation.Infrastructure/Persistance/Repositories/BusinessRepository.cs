using Reservation.Application.Posts.Queries.GetPost;
using Reservation.Application.Posts.Queries.GetPosts;

namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class BusinessRepository(ReservationDbContext context) : IBusinessRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(Business business)
        => _context.Businesses.Add(business);

    public void AddArtist(Artist artist)
        => _context.Artists.Add(artist);

    public void AddPost(Post post)
        => _context.Posts.Add(post);

    public void AddService(Service service)
        => _context.Services.Add(service);

    public async Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .AnyAsync(b => b.PhoneNumber == phoneNumber, cancellationToken);

    public async Task<bool> AnyAsync(Guid businessId, CancellationToken cancellationToken = default)
        => await _context.Businesses.AsQueryable()
                                    .AnyAsync(b => b.Id == businessId, cancellationToken);


    public async Task<bool> AnyAsyncArtist(string name, CancellationToken cancellationToken = default)
        => await _context.Artists.AsQueryable()
                                    .AnyAsync(b => b.Name == name, cancellationToken);

    public async Task<bool> AnyAsyncArtist(Guid artistId, CancellationToken cancellationToken = default)
        => await _context.Artists.AsQueryable()
                                    .AnyAsync(b => b.Id == artistId, cancellationToken);

    public async Task<bool> AnyAsyncPost(string title, CancellationToken cancellationToken)
        => await _context.Posts.AsQueryable()
                                .AnyAsync(b => b.Title == title, cancellationToken);

    public async Task<bool> AnyAsyncService(string name, CancellationToken cancellationToken = default)
        => await _context.Services.AsQueryable()
                                    .AnyAsync(s => s.Name == name, cancellationToken);


    public async Task<Business> FindAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Businesses.AsQueryable()
                                    .Where(b => b.Id == id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Artist> FindAsyncArtist(Guid artistId, CancellationToken cancellationToken)
        => await _context.Artists.AsQueryable()
                                    .Where(b => b.Id == artistId)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Business> FindAsyncByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .Where(b => b.PhoneNumber == phoneNumber)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Service> FindAsyncService(Guid id, CancellationToken cancellationToken)
        => await _context.Services.AsQueryable()
                                    .Where(b => b.Id == id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> GetArtist(Guid artistId, CancellationToken cancellationToken = default)
        => await _context.Artists.AsQueryable()
                                    .Where(c => c.Id == artistId)
                                    .AsNoTracking()
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
        => await _context.Businesses.AsQueryable()
                                    .Include(a => a.Artists)
                                    .Where(c => c.Id == businessId)
                                    .AsNoTracking()
                                    .Select(c => c.Artists.Select(s => new GetArtistByBusinessIdQueryResponse
                                                            (
                                                                s.Id,
                                                                s.Name,
                                                                s.CoverImagePath,
                                                                s.Active
                                                            )).ToList()
                                    ).FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetArtistServices(Guid artistId, CancellationToken cancellationToken)
        => await _context.Artists.AsQueryable()
                                    .Include(a => a.Services)
                                    .Where(c => c.Id == artistId)
                                    .AsNoTracking()
                                    .Select(c => c.Services.Select(s => new GetArtistServicesQueryResponse
                                                            (
                                                                s.Id,
                                                                s.Name,
                                                                s.Time,
                                                                s.Price,
                                                                s.Active
                                                            )).ToList()
                                    ).FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> GetPost(Guid id, CancellationToken cancellationToken)
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

    public async Task<IEnumerable<IResponse>> GetServiceByBusinessId(Guid businessId, CancellationToken cancellationToken)
        => await _context.Services.AsQueryable()
                                    .Where(c => c.BusinessId == businessId)
                                    .AsNoTracking()
                                    .Select(c => new GetServicesByBusinessIdQueryResponse
                                    (
                                        c.Id,
                                        c.Name,
                                        c.Price,
                                        c.Time,
                                        c.Active
                                    ))
                                    .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Search(int page, string key, CancellationToken cancellationToken = default)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .Where(b => b.Address.Contains(key) || b.Name.Contains(key))
                                    .Select(b => new SearchQueryResponse
                                    (
                                        b.Id,
                                        b.Name,
                                        b.Address,
                                        b.City.Name
                                    ))
                                    .Skip((page - 1) * 25)
                                    .Take(25)
                                    .ToListAsync(cancellationToken);
}