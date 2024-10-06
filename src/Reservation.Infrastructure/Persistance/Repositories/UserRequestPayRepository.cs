
namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class UserRequestPayRepository(NewtyDbContext context) : IUserRequestPayRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(UserRequestPay userRequestPay)
        => _context.UserRequestPays.Add(userRequestPay);

    public void Remove(UserRequestPay userRequestPay)
        => _context.UserRequestPays.Remove(userRequestPay);

    public async Task<UserRequestPay> FindAsync(Guid id, string authorizy, CancellationToken cancellationToken)
        => await _context.UserRequestPays.AsQueryable()
                                        .Include(u => u.User)
                                        .Where(r => r.Id == id && r.Authority == authorizy && !r.IsPay)
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> Get(Guid id, Guid userId, CancellationToken cancellationToken)
        => await _context.UserRequestPays.AsQueryable()
                                .Where(b => b.Id == id && b.UserId == userId)
                                .Select(b => new GetUserRequestPayQueryResponse
                                (
                                    b.Id,
                                    b.PayDate,
                                    b.IsPay,
                                    b.Amount,
                                    b.Authority,
                                    b.RefId
                                ))
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Gets(int page, int size, Guid userId, CancellationToken cancellationToken)
        => await _context.UserRequestPays.AsQueryable()
                                .Where(b => b.UserId == userId)
                                .Select(b => new GetUserRequestPaysQueryResponse
                                (
                                    b.Id,
                                    b.PayDate,
                                    b.IsPay,
                                    b.Amount
                                ))
                                .Skip((page - 1) * size)
                                .Take(size)
                                .ToListAsync(cancellationToken);

}