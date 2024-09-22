namespace Reservation.Domain.Repositories;


public interface IBusinessRepository
{
    void Add(Business business);
    void AddUserVIP(UserVIP userVIP);
    Task<Business> FindAsyncByPhoneNumber(string phoneNumber, CancellationToken token = default);
    Task<Business> FindAsync(Guid id, CancellationToken token = default);
    Task<Business> FindAsyncIncludeSMSCredit(Guid id, CancellationToken token = default);
    Task<bool> AnyAsync(string phoneNumber, CancellationToken token = default);
    Task<bool> AnyAsync(Guid businessId, CancellationToken token = default);
    Task<IEnumerable<IResponse>> Search(int page, int size, string key, string city, CancellationToken token = default);
    Task<Business> FindAsyncByIncludePoints(Guid businessId, CancellationToken token = default);
    Task<IResponse> Get(Guid businessId, CancellationToken token = default);
    Task<IEnumerable<IResponse>> GetWaitingValidBusiness(int page, int size, CancellationToken token = default);
    Task<IResponse> GetBusinessById(Guid businessId, CancellationToken token = default);
    Task Active(Guid id, CancellationToken token = default);
    Task<Business> FindAsyncIncludeWallet(Guid businessId, CancellationToken token = default);
}