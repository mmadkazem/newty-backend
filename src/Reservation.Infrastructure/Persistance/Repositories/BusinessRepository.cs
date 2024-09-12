namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class BusinessRepository(NewtyDbContext context)
    : IBusinessRepository
{
    private readonly NewtyDbContext _context = context;

    public async Task Active(Guid id, CancellationToken cancellationToken)
        => await _context.Businesses.Where(u => u.Id == id)
                                    .ExecuteUpdateAsync(s => s.SetProperty(u => u.IsActive, true), cancellationToken);

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
                                        new(b.City.Id, b.City.FaName, b.City.Alternatives, b.City.Key),
                                        b.Holidays,
                                        new Time(b.StartHoursOfWor.Hours, b.StartHoursOfWor.Minutes),
                                        new Time(b.EndHoursOfWor.Hours, b.EndHoursOfWor.Minutes),
                                        b.IsCancelReserveTime,
                                        b.State.ToString()
                                    )).FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> GetBusinessById(Guid businessId, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .Where(b => b.Id == businessId)
                                    .Select(b => new GetBusinessByIdQueryResponse
                                    (
                                        b.Id,
                                        b.Name,
                                        b.Address,
                                        b.CoverImagePath
                                    )).FirstOrDefaultAsync(cancellationToken);
    public async Task<IEnumerable<IResponse>> GetWaitingValidBusiness(int page, int size, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .Where(b => b.State == BusinessState.Waiting)
                                    .Select(b => new GetBusinessesWaitingValidItemQueryResponse
                                    (
                                        b.Id,
                                        b.Name,
                                        b.Description,
                                        b.CoverImagePath,
                                        b.ParvaneKasbImagePath,
                                        b.CardNumber,
                                        b.Address,
                                        b.PhoneNumber,
                                        b.IsCancelReserveTime,
                                        new Time(b.StartHoursOfWor.Hours, b.StartHoursOfWor.Minutes),
                                        new Time(b.EndHoursOfWor.Hours, b.EndHoursOfWor.Minutes),
                                        b.Holidays,
                                        b.City.FaName
                                    ))
                                    .Skip((page - 1) * size)
                                    .Take(size)
                                    .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> Search(int page, int size, string key, string city, CancellationToken cancellationToken = default)
        => await _context.Businesses.AsQueryable()
                                    .AsNoTracking()
                                    .Where(b => b.City.FaName == city && (b.Address.Contains(key) || b.Name.Contains(key)))
                                    .Select(b => new SearchBusinessQueryResponse
                                    (
                                        b.Id,
                                        b.Name,
                                        b.Address,
                                        b.City.FaName
                                    ))
                                    .Skip((page - 1) * size)
                                    .Take(size)
                                    .ToListAsync(cancellationToken);
}