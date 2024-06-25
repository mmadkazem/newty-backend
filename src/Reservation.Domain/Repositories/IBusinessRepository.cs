namespace Reservation.Domain.Repositories;


public interface IBusinessRepository
{
    void Add(Business business);
    Task<Business> FindAsyncByPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default);
    Task<Business> FindAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Guid businessId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> Search(int page, string key, CancellationToken cancellationToken = default);
    Task<double> GetAveragePoints(Guid businessId, CancellationToken cancellationToken);
    Task<Business> FindAsyncByIncludePoints(Guid businessId, CancellationToken cancellationToken);
}