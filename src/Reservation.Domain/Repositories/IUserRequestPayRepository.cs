namespace Reservation.Domain.Repositories;


public interface IUserRequestPayRepository
{
    void Add(UserRequestPay userRequestPay);
    Task<UserRequestPay> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<IResponse>> Gets(int page, Guid userId, CancellationToken cancellationToken);
}