namespace Reservation.Infrastructure.Persistance.Repositories;


public class CityRepository(NewtyDbContext context) : ICityRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(City city)
        => _context.Cities.Add(city);

    public void Remove(City city)
        => _context.Cities.Remove(city);

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken = default)
        => await _context.Cities.AsQueryable()
                                .AnyAsync(c => c.FaName == name, cancellationToken);

    public async Task<City> FindAsync(int Id, CancellationToken cancellationToken = default)
        => await _context.Cities.AsQueryable()
                                .Where(c => c.Id == Id)
                                .FirstOrDefaultAsync(cancellationToken);
    public async Task<City> FindAsyncByName(string name, CancellationToken cancellationToken = default)
        => await _context.Cities.AsQueryable()
                                .Where(c => c.FaName == name)
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetAll(CancellationToken cancellationToken)
        => await _context.Cities.AsQueryable()
                                .Select(c => new GetCitiesQueryResponse
                                (
                                    c.Id,
                                    c.FaName,
                                    c.Alternatives,
                                    c.Key
                                ))
                                .ToListAsync(cancellationToken);

}