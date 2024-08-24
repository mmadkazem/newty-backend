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

    public async Task<Category> FindAsync(Guid Id, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .Where(c => c.Id == Id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetSubCategoryByCategoryId(Guid id, CancellationToken cancellationToken = default)
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

    public async Task<IResponse> GetCategory(Guid id, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .AsNoTracking()
                                    .Select(c => new GetCategoryQueryResponse
                                    (
                                        c.Id,
                                        c.Title,
                                        c.Description,
                                        c.CoverImagePath,
                                        c.ParentCategory.Id
                                    ))
                                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

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

    public async Task<IEnumerable<IResponse>> GetBusiness(Guid categoryId, int page, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .OrderBy(c => c.Points.Average(p => p.Rate))
                                    .Where(b => b.Categories.Any(c => c.Id == categoryId))
                                    .Select(b => new GetCategoryBusinessesQueryResponse
                                    (
                                        b.Id,
                                        b.Name,
                                        b.CoverImagePath,
                                        b.City.FaName
                                    ))
                                    .Skip((page - 1) * 25)
                                    .Take(25)
                                    .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Search(string key, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .Where(b => b.Name.Contains(key))
                                    .Select(b => new SearchCategoryQueryResponse
                                    (
                                        b.Id,
                                        b.Name,
                                        b.CoverImagePath
                                    ))
                                    .ToListAsync(cancellationToken);
}