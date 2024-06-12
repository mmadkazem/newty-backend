

namespace Reservation.Infrastructure.Persistance.Repositories;

public sealed class UserRepository(ReservationDbContext context) : IUserRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(User user)
        => _context.Users.Add(user);

    public async Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken)
        => await _context.Users
            .AsQueryable()
            .AnyAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);

    public async Task<bool> AnyAsync(Guid userId, CancellationToken cancellationToken = default)
        => await _context.Users
            .AsQueryable()
            .AnyAsync(u => u.Id == userId, cancellationToken);

    public async Task<User> FindAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Users.AsQueryable()
                                .Where(u => u.Id == id)
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<User> FindByNumber(string phoneNumber, CancellationToken cancellationToken)
        => await _context.Users.AsQueryable()
                                .Where(u => u.PhoneNumber == phoneNumber)
                                .FirstOrDefaultAsync(cancellationToken);
}