namespace Reservation.Domain.Repositories;


public interface ICategoryRepository
{
    void Add(Category category);
    void Remove(Category category);
    Task<IEnumerable<IResponse>> GetSubCategoryByCategoryId(Guid Id, CancellationToken cancellationToken = default);
    Task<Category> FindAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<Category> FindAsyncByIncludePoints(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> Top3(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string title, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetCategories(CancellationToken cancellationToken = default);
    Task<IResponse> GetCategory(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetBusiness(Guid categoryId, int page, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> Search(string key, CancellationToken cancellationToken = default);
}