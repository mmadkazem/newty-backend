namespace Reservation.Domain.Repositories;


public interface ICategoryRepository
{
    void Add(Category category);
    void Remove(Category category);
    Task<IEnumerable<IResponse>> GetSubCategoryByCategoryId(int Id, CancellationToken cancellationToken = default);
    Task<Category> FindAsync(int Id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetMainCategory(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string title, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetCategories(CancellationToken cancellationToken = default);
    Task<IResponse> GetCategory(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> GetBusiness(int categoryId, int page, CancellationToken cancellationToken = default);
    Task<IEnumerable<IResponse>> Search(string key, CancellationToken cancellationToken = default);
}