namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class ReserveTimeRepository(ReservationDbContext context)
    : IReserveTimeRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(ReserveTimeReceipt reserveTime)
        => _context.ReserveTimesReceipt.Add(reserveTime);

    public void Add(ReserveTimeSender reserveTime)
        => _context.ReserveTimesSender.Add(reserveTime);

    public async Task<ReserveTimeReceipt> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .Where(r => r.Id == id)
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<List<ReserveTimeReceipt>> FindAsyncByBusinessId(Guid businessId, CancellationToken cancellationToken)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .Where(r => r.BusinessId == businessId && !r.Finished)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<ReserveTimeReceipt>> FindAsyncByUserId(Guid userId, CancellationToken cancellationToken = default)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .Where(r => r.UserId == userId && !r.Finished)
                                        .ToListAsync(cancellationToken);

    public async Task<List<ReserveTimeSender>> FindAsyncBusinessSenderId(Guid businessSenderId, CancellationToken cancellationToken)
        => await _context.ReserveTimesSender.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .Where(r => r.BusinessSenderId == businessSenderId && !r.Finished)
                                        .ToListAsync(cancellationToken);

    public async Task<IResponse> Get(Guid id, CancellationToken cancellationToken = default)
        => await _context.ReserveTimesReceipt.AsQueryable()
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
        => await _context.ReserveTimesReceipt.AsQueryable()
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
        => await _context.ReserveTimesReceipt.AsQueryable()
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

    public async Task<IEnumerable<IResponse>> GetBusinessReserveTimesSender(int page, bool finished, Guid businessId, CancellationToken cancellationToken)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.BusinessId == businessId && r.Finished == finished)
                                        .Select(c => new GetReserveTimeSenderQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.UserId,
                                            c.State.ToString(),
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

    public async Task<IEnumerable<IResponse>> GetBusinessReserveTimesSenderByState(int page, ReserveState state, Guid businessId, CancellationToken cancellationToken)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.BusinessId == businessId && r.State == state)
                                        .Select(c => new GetReserveTimeSenderQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.UserId,
                                            c.State.ToString(),
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
        => await _context.ReserveTimesReceipt.AsQueryable()
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
        => await _context.ReserveTimesReceipt.AsQueryable()
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

    public async Task<ReserveTimeSender> FindAsyncReserveTimeSender(Guid id, CancellationToken cancellationToken = default)
        => await _context.ReserveTimesSender.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .Where(r => r.Id == id)
                                        .FirstOrDefaultAsync(cancellationToken);
}