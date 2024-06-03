namespace Reservation.Infrastructure.Persistance.Repositories;


public class CategoryRepository(ReservationDbContext context) : ICategoryRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(Category category)
        => _context.Categories.Add(category);

    public void Add(SubCategory subCategory)
        => _context.SubCategories.Add(subCategory);

    public async Task<bool> AnyAsync(string title, CancellationToken cancellationToken)
        => await _context.Categories.AsQueryable()
                                    .AnyAsync(c => c.Title == title, cancellationToken);

    public async Task<bool> AnyAsyncSunCategory(string title, CancellationToken cancellationToken = default)
        => await _context.SubCategories.AsQueryable()
                                        .AnyAsync(c => c.Title == title, cancellationToken);

    public async Task<Category> FindAsync(Guid Id, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .Where(c => c.Id == Id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<SubCategory> FindAsyncSubCategory(Guid Id, CancellationToken cancellationToken = default)
        => await _context.SubCategories.AsQueryable()
                                        .Where(c => c.Id == Id)
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Get(Guid id, CancellationToken cancellationToken = default)
        => await _context.SubCategories.AsQueryable()
                                        .Where(c => c.Category.Id == id)
                                        .AsNoTracking()
                                        .Select(c => new GetSubCategoryByCategoryIdQueryResponse
                                        (
                                            c.Id,
                                            c.Title,
                                            c.Description,
                                            c.CoverImagePath,
                                            c.AveragePoint
                                        ))
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetCategories(int page, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                        .AsNoTracking()
                                        .OrderBy(c => c.AveragePoint)
                                        .Select(c => new GetCategoriesQueryResponse
                                        (
                                            c.Id,
                                            c.Title,
                                            c.Description,
                                            c.CoverImagePath,
                                            c.AveragePoint
                                        ))
                                        .Skip((page - 1) * 25)
                                        .Take(25)
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
                                        c.AveragePoint
                                    ))
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetSubCategories(int page, CancellationToken cancellationToken)
        => await _context.SubCategories.AsQueryable()
                                        .AsNoTracking()
                                        .Select(c => new GetSubCategoriesQueryResponse
                                        (
                                            c.Id,
                                            c.Title,
                                            c.Description,
                                            c.CoverImagePath,
                                            c.AveragePoint
                                        ))
                                        .Skip((page - 1) * 25)
                                        .Take(25)
                                        .ToListAsync(cancellationToken);

    public async Task<IResponse> GetSubCategory(Guid id, CancellationToken cancellationToken = default)
        => await _context.SubCategories.AsQueryable()
                                        .AsNoTracking()
                                        .Select(c => new GetSubCategoryByIdQueryResponse
                                        (
                                            c.Id,
                                            c.Title,
                                            c.Description,
                                            c.CoverImagePath,
                                            c.AveragePoint
                                        ))
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Top3(CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .AsNoTracking()
                                    .OrderBy(c => c.AveragePoint)
                                    .Take(3)
                                    .Select(c => new GetTop3SubCategoryQueryResponse
                                    (
                                        c.Id,
                                        c.Title,
                                        c.Description,
                                        c.CoverImagePath,
                                        c.AveragePoint
                                    ))
                                    .ToListAsync(cancellationToken);
}