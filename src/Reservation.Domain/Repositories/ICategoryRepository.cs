namespace Reservation.Domain.Repositories;


public interface ICategoryRepository
{
    void Add(Category category);
    void Add(SubCategory subCategory);
    Task<IEnumerable<IResponse>> Get(Guid Id, CancellationToken cancellationToken = default);
    Task<Category> FindAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<SubCategory> FindAsyncSubCategory(Guid Id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> Top3(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string title, CancellationToken cancellationToken = default);
    Task<bool> AnyAsyncSunCategory(string title, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetSubCategories(int page, CancellationToken cancellationToken = default);
    Task<IResponse> GetSubCategory(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetCategories(int page, CancellationToken cancellationToken = default);
    Task<IResponse> GetCategory(Guid id, CancellationToken cancellationToken = default);
}