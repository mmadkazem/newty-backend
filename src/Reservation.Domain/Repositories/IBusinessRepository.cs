namespace Reservation.Domain.Repositories;


public interface IBusinessRepository
{
    void Add(Business business);
    void AddService(Service service);
    void AddArtist(Artist artist);
    void AddPost(Post post);
    Task<Business> FindAsyncByPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default);
    Task<Business> FindAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Guid businessId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> Search(int page, string key, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetServiceByBusinessId(Guid businessId, CancellationToken cancellationToken = default);
    Task<Service> FindAsyncService(Guid serviceId, CancellationToken cancellationToken = default);
    Task<bool> AnyAsyncService(string name, CancellationToken cancellationToken = default);
    Task<Artist> FindAsyncArtist(Guid artistId, CancellationToken cancellationToken = default);
    Task<IResponse> GetArtist(Guid artistId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetArtistServices(Guid artistId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetArtistByBusinessId(Guid businessId, CancellationToken cancellationToken = default);
    Task<bool> AnyAsyncArtist(string name, CancellationToken cancellationToken = default);
    Task<bool> AnyAsyncArtist(Guid artistId, CancellationToken cancellationToken = default);
    Task<bool> AnyAsyncPost(string title, CancellationToken cancellationToken);
    Task<IResponse> GetPost(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<IResponse>> GetPosts(int page, Guid businessId, CancellationToken cancellationToken);
    void AddSmsCredit(SmsCredit smsCredit);
}