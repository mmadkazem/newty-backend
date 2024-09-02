namespace Reservation.Infrastructure.Persistance.Repositories;


public class CategoryRepository(NewtyDbContext context) : ICategoryRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(Category category)
        => _context.Categories.Add(category);

    public void Remove(Category category)
        => _context.Categories.Remove(category);

    public async Task<bool> AnyAsync(string title, CancellationToken cancellationToken)
        => await _context.Categories.AsQueryable()
                                    .AnyAsync(c => c.Title == title, cancellationToken);

    public async Task<Category> FindAsync(int Id, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .Where(c => c.Id == Id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetSubCategoryByCategoryId(int id, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .AsNoTracking()
                                    .Where(c => c.ParentCategory.Id == id)
                                    .Select(c => new GetCategoryQueryResponse
                                    (
                                        c.Id,
                                        c.Title,
                                        c.Description,
                                        c.CoverImagePath,
                                        c.ParentCategory.Id
                                    ))
                                    .ToListAsync(cancellationToken);


    public async Task<IEnumerable<IResponse>> GetCategories(CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                        .AsNoTracking()
                                        .Select(c => new GetCategoriesQueryResponse
                                        (
                                            c.Id,
                                            c.Title,
                                            c.Description,
                                            c.CoverImagePath,
                                            c.ParentCategory.Id
                                        ))
                                        .ToListAsync(cancellationToken);

    public async Task<IResponse> GetCategory(int id, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .AsNoTracking()
                                    .Where(c => c.Id == id)
                                    .Select(c => new GetCategoryQueryResponse
                                    (
                                        c.Id,
                                        c.Title,
                                        c.Description,
                                        c.CoverImagePath,
                                        c.ParentCategory.Id
                                    ))
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetMainCategory(CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .AsNoTracking()
                                    .Where(c => c.ParentCategory == null)
                                    .Select(c => new GetMainCategoryQueryResponse
                                    (
                                        c.Id,
                                        c.Title,
                                        c.Description,
                                        c.CoverImagePath
                                    ))
                                    .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetBusiness(int categoryId, int page, int size, string city, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .OrderBy(c => c.Points.Average(p => p.Rate))
                                    .Where(b => b.Categories.Any(c => c.Id == categoryId) && b.City.FaName == city)
                                    .Select(b => new GetCategoryBusinessesQueryResponse
                                    (
                                        b.Id,
                                        b.Name,
                                        b.CoverImagePath,
                                        b.IsClose,
                                        b.Address,
                                        (double)b.Points.Average(p => p.Rate)
                                    ))
                                    .Skip((page - 1) * size)
                                    .Take(size)
                                    .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Search(string key, CancellationToken cancellationToken)
        => await _context.Categories.AsQueryable()
                                    .AsNoTracking()
                                    .Where(b => b.Title.Contains(key))
                                    .Select(b => new SearchCategoryQueryResponse
                                    (
                                        b.Id,
                                        b.Title,
                                        b.CoverImagePath
                                    ))
                                    .ToListAsync(cancellationToken);
}