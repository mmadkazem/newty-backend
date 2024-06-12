namespace Reservation.Domain.Repositories;

public interface IReserveTimeRepository
{
    void Add(ReserveTimeOut reserveTime);
    Task<ReserveTimeOut> FindAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ReserveTimeOut>> FindAsyncByBusinessId(Guid businessId, CancellationToken cancellationToken = default);
    Task<IEnumerable<ReserveTimeOut>> FindAsyncByUserId(Guid userId, CancellationToken cancellationToken = default);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetBusinessReserveTimeByState(int page, ReserveState state, Guid businessId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetBusinessReserveTimes(int page, Guid businessId, bool finished, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetUserReserveTimeByState(int page, Guid userId, ReserveState state, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetUserReserveTimes(int page, Guid userId, bool finished, CancellationToken cancellationToken = default);
}