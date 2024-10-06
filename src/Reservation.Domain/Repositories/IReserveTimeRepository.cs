namespace Reservation.Domain.Repositories;

public interface IReserveTimeRepository
{
    void Add(ReserveTimeReceipt reserveTime);
    void Add(ReserveTimeSender reserveTime);
    Task<ReserveTimeReceipt> FindAsyncByIdAndAuthority(Guid id, string authority, CancellationToken cancellationToken = default);
    Task<ReserveTimeReceipt> FindAsyncIncludeService(Guid id, CancellationToken cancellationToken = default);
    Task<ReserveTimeReceipt> FindAsyncIncludeTransaction(Guid id, CancellationToken cancellationToken = default);
    Task<ReserveTimeSender> FindAsyncReserveTimeSender(Guid id, CancellationToken cancellationToken = default);
    Task<List<ReserveTimeReceipt>> FindAsyncByBusinessId(Guid businessId, CancellationToken cancellationToken = default);
    Task<List<ReserveTimeSender>> FindAsyncBusinessSenderId(Guid businessSenderId, CancellationToken cancellationToken);
    Task<IEnumerable<ReserveTimeReceipt>> FindAsyncByUserId(Guid userId, CancellationToken cancellationToken = default);
    Task<IResponse> Get(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetBusinessReserveTimeByState(int page, int size, ReserveState state, Guid businessId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetBusinessReserveTimes(int page, int size, Guid businessId, bool finished, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetUserReserveTimeByState(int page, int size, Guid userId, ReserveState state, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetUserReserveTimes(int page, int size, Guid userId, bool finished, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetBusinessReserveTimesSender(int page, int size, bool finished, Guid businessId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetBusinessReserveTimesSenderByState(int page, int size, ReserveState state, Guid businessId, CancellationToken cancellationToken = default);
    Task<IResponse> GetReserveTimeSender(Guid id, CancellationToken cancellationToken = default);
}