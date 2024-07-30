namespace Reservation.Domain.Repositories;


public interface IBusinessRepository
{
    void Add(Business business);
    void AddUserVIP(UserVIP userVIP);
    Task<Business> FindAsyncByPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default);
    Task<Business> FindAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Business> FindAsyncIncludeSMSCredit(Guid id, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Guid businessId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> Search(int page, string key, CancellationToken cancellationToken = default);
    Task<Business> FindAsyncByIncludePoints(Guid businessId, CancellationToken cancellationToken);
    Task<IResponse> Get(Guid businessId, CancellationToken cancellationToken);
}