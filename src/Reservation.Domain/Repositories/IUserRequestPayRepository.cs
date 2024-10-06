namespace Reservation.Domain.Repositories;


public interface IUserRequestPayRepository
{
    void Add(UserRequestPay userRequestPay);
    void Remove(UserRequestPay userRequestPay);
    Task<UserRequestPay> FindAsync(Guid id, string authorizy, CancellationToken cancellationToken);
    Task<IResponse> Get(Guid id, Guid userId, CancellationToken cancellationToken);
    Task<IEnumerable<IResponse>> Gets(int page, int size, Guid userId, CancellationToken cancellationToken);
}