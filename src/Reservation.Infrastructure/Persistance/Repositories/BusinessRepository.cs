namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class BusinessRepository(ReservationDbContext context) : IBusinessRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(Business business)
        => _context.Businesses.Add(business);

    public void AddUserVIP(UserVIP userVIP)
        => _context.UsersVIP.Add(userVIP);


    public async Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .AnyAsync(b => b.PhoneNumber == phoneNumber, cancellationToken);

    public async Task<bool> AnyAsync(Guid businessId, CancellationToken cancellationToken = default)
        => await _context.Businesses.AsQueryable()
                                    .AnyAsync(b => b.Id == businessId, cancellationToken);

    public async Task<Business> FindAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Businesses.AsQueryable()
                                    .Where(b => b.Id == id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Business> FindAsyncByIncludePoints(Guid businessId, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .Include(b => b.Points)
                                    .Where(b => b.Id == businessId)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Business> FindAsyncByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .Where(b => b.PhoneNumber == phoneNumber)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Business> FindAsyncIncludeSMSCredit(Guid id, CancellationToken cancellationToken = default)
        => await _context.Businesses.AsQueryable()
                                    .Include(b => b.SmsCredit)
                                    .Where(b => b.Id == id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> Get(Guid businessId, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .Where(b => b.Id == businessId)
                                    .Select(b => new GetBusinessQueryResponse
                                    (
                                        b.Id,
                                        b.PhoneNumber,
                                        b.Name,
                                        b.CoverImagePath,
                                        b.ParvaneKasbImagePath,
                                        b.Description,
                                        b.Address,
                                        b.City.Name,
                                        b.Holidays,
                                        b.StartHoursOfWor,
                                        b.EndHoursOfWor,
                                        b.IsCancelReserveTime
                                    )).FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Search(int page, string key, CancellationToken cancellationToken = default)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .Where(b => b.Address.Contains(key) || b.Name.Contains(key))
                                    .Select(b => new SearchQueryResponse
                                    (
                                        b.Id,
                                        b.Name,
                                        b.Address,
                                        b.City.Name
                                    ))
                                    .Skip((page - 1) * 25)
                                    .Take(25)
                                    .ToListAsync(cancellationToken);
}