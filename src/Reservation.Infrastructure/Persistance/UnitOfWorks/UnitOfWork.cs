namespace Reservation.Infrastructure.Persistance.UnitOfWorks;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ReservationDbContext _context;
    public UnitOfWork(
        ReservationDbContext context,
        IUserRepository users,
        ICityRepository cities,
        IBusinessRepository businesses,
        ICategoryRepository categories)
    {
        _users = users;
        _context = context;
        _cities = cities;
        _businesses = businesses;
        _categories = categories;
    }

    private readonly IUserRepository _users;
    public IUserRepository Users => _users;

    private readonly ICityRepository _cities;
    public ICityRepository Cities => _cities;

    private readonly IBusinessRepository _businesses;
    public IBusinessRepository Businesses => _businesses;

    private readonly ICategoryRepository _categories;
    public ICategoryRepository Categories => _categories;

    public async Task SaveChangeAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}