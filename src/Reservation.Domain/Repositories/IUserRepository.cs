namespace Reservation.Domain.Repositories;


public interface IUserRepository
{
    void Add(User user);
    Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<User> FindAsyncByNumber(string phoneNumber, CancellationToken cancellationToken = default);
    Task<User> FindAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken);
}