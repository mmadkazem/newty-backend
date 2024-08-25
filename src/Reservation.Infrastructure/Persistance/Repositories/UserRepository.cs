using Reservation.Application.Account.Queries.GetUserInfo;

namespace Reservation.Infrastructure.Persistance.Repositories;

public sealed class UserRepository(NewtyDbContext context) : IUserRepository
{
    private readonly NewtyDbContext _context = context;

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

    public async Task<User> FindAsyncByNumber(string phoneNumber, CancellationToken cancellationToken)
        => await _context.Users.AsQueryable()
                                .Where(u => u.PhoneNumber == phoneNumber)
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> Get(Guid id, CancellationToken cancellationToken)
        => await _context.Users.AsQueryable()
                                .AsNoTracking()
                                .Where(u => u.Id == id)
                                .Select(u => new GetUserInfoQueryResponse
                                (
                                    u.Id,
                                    u.PhoneNumber,
                                    u.FullName,
                                    u.City.FaName
                                ))
                                .FirstOrDefaultAsync(cancellationToken);
}