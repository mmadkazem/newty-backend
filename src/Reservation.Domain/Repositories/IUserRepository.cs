namespace Reservation.Domain.Repositories;


public interface IUserRepository
{
    void Add(User user);
    Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken = default);
    Task<User> FindByNumber(string phoneNumber, CancellationToken cancellationToken = default);
    Task<User> FindAsync(Guid id, CancellationToken cancellationToken = default);
}