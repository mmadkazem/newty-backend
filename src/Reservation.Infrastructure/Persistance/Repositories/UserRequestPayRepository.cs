
namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class UserRequestPayRepository(NewtyDbContext context, NewtyDbContextCommand contextCommand) : IUserRequestPayRepository
{
    private readonly NewtyDbContext _context = context;
    private readonly NewtyDbContextCommand _contextCommand = contextCommand;


    public void Add(UserRequestPay userRequestPay)
        => _contextCommand.UserRequestPays.Add(userRequestPay);

    public void Remove(UserRequestPay userRequestPay)
        => _contextCommand.UserRequestPays.Remove(userRequestPay);

    public async Task<UserRequestPay> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _contextCommand.UserRequestPays.AsQueryable()
                                            .FirstOrDefaultAsync(r => r.Id == id && !r.IsPay, cancellationToken);

    public async Task<IResponse> Get(Guid id, CancellationToken cancellationToken)
        => await _context.UserRequestPays.AsQueryable()
                                .AsNoTracking()
                                .Where(b => b.Id == id)
                                .Select(b => new GetUserRequestPayQueryResponse
                                (
                                    b.Id,
                                    b.PayDate,
                                    b.IsPay,
                                    b.Amount,
                                    b.Authorizy,
                                    b.RefId
                                ))
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Gets(int page, int size, Guid userId, CancellationToken cancellationToken)
        => await _context.UserRequestPays.AsQueryable()
                                .AsNoTracking()
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