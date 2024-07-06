namespace Reservation.Infrastructure.Persistance.Repositories;


public class CategoryRepository(ReservationDbContext context) : ICategoryRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(Category category)
        => _context.Categories.Add(category);

    public async Task<bool> AnyAsync(string title, CancellationToken cancellationToken)
        => await _context.Categories.AsQueryable()
                                    .AnyAsync(c => c.Title == title, cancellationToken);

    public async Task<Category> FindAsync(Guid Id, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .Where(c => c.Id == Id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Category> FindAsyncByIncludePoints(Guid categoryId, CancellationToken cancellationToken)
        => await _context.Categories.AsQueryable()
                                    .Include(c => c.Points)
                                    .Where(c => c.Id == categoryId)
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
                                        c.Points.Average(p => p.Rate)
                                    ))
                                    .ToListAsync(cancellationToken);

    public async Task<double> GetAveragePoints(Guid categoryId, CancellationToken cancellationToken)
        => await _context.Categories.AsQueryable()
                                .Where(a => a.Id == categoryId)
                                .Select(a => a.Points.Average(p => p.Rate))
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetCategories(int page, CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                        .AsNoTracking()
                                        .OrderBy(c => c.Points.Average(p => p.Rate))
                                        .Select(c => new GetCategoriesQueryResponse
                                        (
                                            c.Id,
                                            c.Title,
                                            c.Description,
                                            c.CoverImagePath,
                                            c.Points.Average(p => p.Rate)
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
                                        c.Points.Average(p => p.Rate)
                                    ))
                                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<IEnumerable<IResponse>> Top3(CancellationToken cancellationToken = default)
        => await _context.Categories.AsQueryable()
                                    .AsNoTracking()
                                    .Where(c => c.ParentCategory == null)
                                    .OrderBy(c => c.Points.Average(p => p.Rate))
                                    .Take(3)
                                    .Select(c => new GetTop3SubCategoryQueryResponse
                                    (
                                        c.Id,
                                        c.Title,
                                        c.Description,
                                        c.CoverImagePath,
                                        c.Points.Average(p => p.Rate)
                                    ))
                                    .ToListAsync(cancellationToken);
}