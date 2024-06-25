
namespace Reservation.Infrastructure.Persistance.Repositories;


public class CityRepository(ReservationDbContext context) : ICityRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(City city)
        => _context.Cities.Add(city);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default)
        => await _context.Cities.AsQueryable()
                                .AnyAsync(c => c.Name == name, cancellationToken);

    public async Task<City> FindAsync(Guid Id, CancellationToken cancellationToken = default)
        => await _context.Cities.AsQueryable()
                                .Where(c => c.Id == Id)
                                .FirstOrDefaultAsync(cancellationToken);
    public async Task<City> FindAsyncByName(string name, CancellationToken cancellationToken = default)
        => await _context.Cities.AsQueryable()
                                .Where(c => c.Name == name)
                                .FirstOrDefaultAsync(cancellationToken);

    public Task<IResponse> Get(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<IResponse>> GetAll(CancellationToken cancellationToken)
        => await _context.Cities.AsQueryable()
                                .AsNoTracking()
                                .Select(c => new GetCitiesQueryResponse
                                (
                                    c.Id,
                                    c.Name,
                                    c.State
                                ))
                                .ToListAsync(cancellationToken);
}