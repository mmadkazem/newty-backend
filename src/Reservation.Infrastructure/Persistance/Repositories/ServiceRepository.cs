namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class ServiceRepository(NewtyDbContext context) : IServiceRepository
{
    private readonly NewtyDbContext _context = context;
    public void Add(BusinessService service)
        => _context.Services.Add(service);

    public void Remove(BusinessService service)
        => _context.Services.Remove(service);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default)
        => await _context.Services.AsQueryable()
                                    .AnyAsync(s => s.Name == name, cancellationToken);

    public async Task<BusinessService> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Services.AsQueryable()
                                    .Include(s => s.Business)
                                    .Include(u => u.Artist)
                                    .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<BusinessService> FindAsyncIncludeArtist(Guid serviceId, CancellationToken cancellationToken)
        => await _context.Services.AsQueryable()
                                    .Include(s => s.Artist)
                                    .FirstOrDefaultAsync(b => b.Id == serviceId, cancellationToken);


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

    public async Task<IEnumerable<IResponse>> GetServiceByBusinessId(int page, int size, Guid businessId, CancellationToken cancellationToken)
        => await _context.Services.AsQueryable()
                                    .Where(c => c.BusinessId == businessId)
                                    .AsNoTracking()
                                    .Select(c => new GetServicesByBusinessIdQueryResponse
                                    (
                                        c.Id,
                                        c.Name,
                                        c.Price,
                                        new Time(c.Time.Hour, c.Time.Minute),
                                        c.Active
                                    ))
                                    .Skip((page - 1) * size)
                                    .Take(size)
                                    .ToListAsync(cancellationToken);

}