namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class ReserveTimeRepository(ReservationDbContext context)
    : IReserveTimeRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(ReserveTimeOut reserveTime)
        => _context.ReserveTimesOut.Add(reserveTime);

    public async Task<ReserveTimeOut> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _context.ReserveTimesOut.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .AsSplitQuery()
                                        .Where(r => r.Id == id)
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<ReserveTimeOut>> FindAsyncByBusinessId(Guid businessId, CancellationToken cancellationToken)
        => await _context.ReserveTimesOut.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .AsSplitQuery()
                                        .Where(r => r.BusinessId == businessId)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<ReserveTimeOut>> FindAsyncByUserId(Guid userId, CancellationToken cancellationToken = default)
        => await _context.ReserveTimesOut.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .AsSplitQuery()
                                        .Where(r => r.UserId == userId)
                                        .ToListAsync(cancellationToken);

    public async Task<IResponse> Get(Guid id, CancellationToken cancellationToken = default)
        => await _context.ReserveTimesOut.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.Id == id)
                                        .Select(c => new GetReserveTimeQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.UserId,
                                            c.ReserveItems.Select(r => new ReserveItemsResponse
                                                            (
                                                                r.Id,
                                                                r.StartDate,
                                                                r.EndDate,
                                                                r.Price,
                                                                r.ServiceId
                                                            )).ToList()
                                        ))
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetBusinessReserveTimeByState(int page, ReserveState state, Guid businessId, CancellationToken cancellationToken)
        => await _context.ReserveTimesOut.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.BusinessId == businessId && r.State == state)
                                        .Select(c => new GetReserveTimeQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.UserId,
                                            c.ReserveItems.Select(r => new ReserveItemsResponse
                                                            (
                                                                r.Id,
                                                                r.StartDate,
                                                                r.EndDate,
                                                                r.Price,
                                                                r.ServiceId
                                                            )).ToList()
                                        ))
                                        .Skip((page - 1) * 20)
                                        .Take(20)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetBusinessReserveTimes(int page, Guid businessId, bool finished, CancellationToken cancellationToken)
        => await _context.ReserveTimesOut.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.BusinessId == businessId && r.Finished == finished && r.State == ReserveState.Confirmed)
                                        .Select(c => new GetReserveTimeQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.UserId,
                                            c.ReserveItems.Select(r => new ReserveItemsResponse
                                                            (
                                                                r.Id,
                                                                r.StartDate,
                                                                r.EndDate,
                                                                r.Price,
                                                                r.ServiceId
                                                            )).ToList()
                                        ))
                                        .Skip((page - 1) * 20)
                                        .Take(20)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetUserReserveTimeByState(int page, Guid userId, ReserveState state, CancellationToken cancellationToken)
        => await _context.ReserveTimesOut.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.UserId == userId && r.State == state)
                                        .Select(c => new GetReserveTimeQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.UserId,
                                            c.ReserveItems.Select(r => new ReserveItemsResponse
                                                            (
                                                                r.Id,
                                                                r.StartDate,
                                                                r.EndDate,
                                                                r.Price,
                                                                r.ServiceId
                                                            )).ToList()
                                        ))
                                        .Skip((page - 1) * 20)
                                        .Take(20)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetUserReserveTimes(int page, Guid userId, bool finished, CancellationToken cancellationToken)
        => await _context.ReserveTimesOut.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.UserId == userId && r.Finished == finished && r.State == ReserveState.Confirmed)
                                        .Select(c => new GetReserveTimeQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.UserId,
                                            c.ReserveItems.Select(r => new ReserveItemsResponse
                                                            (
                                                                r.Id,
                                                                r.StartDate,
                                                                r.EndDate,
                                                                r.Price,
                                                                r.ServiceId
                                                            )).ToList()
                                        ))
                                        .Skip((page - 1) * 20)
                                        .Take(20)
                                        .ToListAsync(cancellationToken);
}