
namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class ServiceRepository(ReservationDbContext context) : IServiceRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(Service service)
        => _context.Services.Add(service);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default)
        => await _context.Services.AsQueryable()
                                    .AnyAsync(s => s.Name == name, cancellationToken);

    public async Task<Service> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Services.AsQueryable()
                                    .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<IEnumerable<IResponse>> GetArtistServices(Guid artistId, CancellationToken cancellationToken)
        => await _context.Artists.AsQueryable()
                                    .AsNoTracking()
                                    .Include(a => a.Services)
                                    .AsSplitQuery()
                                    .Where(c => c.Id == artistId)
                                    .Select(c => c.Services.Select(s => new GetArtistServicesQueryResponse
                                                            (
                                                                s.Id,
                                                                s.Name,
                                                                s.Time,
                                                                s.Price,
                                                                s.Active
                                                            )).ToList()
                                    ).FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetServiceByBusinessId(int page, Guid businessId, CancellationToken cancellationToken)
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
                                    .Skip((page - 1) * 25)
                                    .Take(25)
                                    .ToListAsync(cancellationToken);
}