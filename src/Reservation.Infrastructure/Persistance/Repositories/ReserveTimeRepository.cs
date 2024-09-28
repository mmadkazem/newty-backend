namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class ReserveTimeRepository(NewtyDbContext context)
    : IReserveTimeRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(ReserveTimeReceipt reserveTime)
        => _context.ReserveTimesReceipt.Add(reserveTime);

    public void Add(ReserveTimeSender reserveTime)
        => _context.ReserveTimesSender.Add(reserveTime);

    public async Task<ReserveTimeReceipt> FindAsyncIncludeService(Guid id, CancellationToken cancellationToken)
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
                                        .Where(r => r.BusinessReceiptId == businessId && !r.Finished)
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
                                        .Select(c => new GetReserveTimeDetailQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.UserId,
                                            c.State.ToString(),
                                            c.Finished,
                                            c.BusinessReceipt.IsCancelReserveTime,
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

    public async Task<IResponse> GetReserveTimeSender(Guid id, CancellationToken cancellationToken = default)
        => await _context.ReserveTimesSender.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.Id == id)
                                        .Select(c => new GetReserveTimeSenderByIdQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.TotalPrice,
                                            c.BusinessReceiptId,
                                            c.State.ToString(),
                                            c.Finished,
                                            c.BusinessReceipt.IsCancelReserveTime,
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

    public async Task<IEnumerable<IResponse>> GetBusinessReserveTimeByState(int page, int size, ReserveState state, Guid businessId, CancellationToken cancellationToken)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.BusinessReceiptId == businessId && r.State == state)
                                        .Select(c => new GetReserveTimeBusinessReceiptQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.User.FullName,
                                            c.BusinessReceipt.IsCancelReserveTime
                                        ))
                                        .Skip((page - 1) * size)
                                        .Take(size)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetBusinessReserveTimes(int page, int size, Guid businessId, bool finished, CancellationToken cancellationToken)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.BusinessReceiptId == businessId && r.Finished == finished && r.State == ReserveState.Confirmed)
                                        .Select(c => new GetReserveTimeUserQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.BusinessReceipt.Name,
                                            c.BusinessReceipt.Address,
                                            c.BusinessReceipt.CoverImagePath,
                                            c.BusinessReceipt.IsCancelReserveTime
                                        ))
                                        .Skip((page - 1) * size)
                                        .Take(size)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetBusinessReserveTimesSender(int page, int size, bool finished, Guid businessId, CancellationToken cancellationToken)
        => await _context.ReserveTimesSender.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.BusinessReceiptId == businessId && r.Finished == finished)
                                        .Select(c => new GetReserveTimeBusinessSenderQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.BusinessReceipt.Name,
                                            c.BusinessReceipt.Address,
                                            c.BusinessReceipt.CoverImagePath,
                                            c.BusinessReceipt.IsCancelReserveTime
                                        ))
                                        .Skip((page - 1) * size)
                                        .Take(size)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetBusinessReserveTimesSenderByState(int page, int size, ReserveState state, Guid businessId, CancellationToken cancellationToken)
        => await _context.ReserveTimesSender.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.BusinessReceiptId == businessId && r.State == state && !r.Finished)
                                        .Select(c => new GetReserveTimeBusinessSenderQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.BusinessReceipt.Name,
                                            c.BusinessReceipt.Address,
                                            c.BusinessReceipt.CoverImagePath,
                                            c.BusinessReceipt.IsCancelReserveTime
                                        ))
                                        .Skip((page - 1) * size)
                                        .Take(size)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetUserReserveTimeByState(int page, int size, Guid userId, ReserveState state, CancellationToken cancellationToken)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.UserId == userId && r.State == state && !r.Finished)
                                        .Select(c => new GetReserveTimeUserQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.BusinessReceipt.Name,
                                            c.BusinessReceipt.Address,
                                            c.BusinessReceipt.CoverImagePath,
                                            c.BusinessReceipt.IsCancelReserveTime
                                        ))
                                        .Skip((page - 1) * size)
                                        .Take(size)
                                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetUserReserveTimes(int page, int size, Guid userId, bool finished, CancellationToken cancellationToken)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .AsNoTracking()
                                        .Where(r => r.UserId == userId && r.Finished == finished && r.State == ReserveState.Confirmed)
                                        .Select(c => new GetReserveTimeUserQueryResponse
                                        (
                                            c.Id,
                                            c.TotalStartDate,
                                            c.TotalEndDate,
                                            c.BusinessReceipt.Name,
                                            c.BusinessReceipt.Address,
                                            c.BusinessReceipt.CoverImagePath,
                                            c.BusinessReceipt.IsCancelReserveTime
                                        ))
                                        .Skip((page - 1) * size)
                                        .Take(size)
                                        .ToListAsync(cancellationToken);

    public async Task<ReserveTimeSender> FindAsyncReserveTimeSender(Guid id, CancellationToken cancellationToken = default)
        => await _context.ReserveTimesSender.AsQueryable()
                                        .Include(r => r.ReserveItems)
                                        .ThenInclude(r => r.Service)
                                        .ThenInclude(s => s.Artist)
                                        .Where(r => r.Id == id)
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<ReserveTimeReceipt> FindAsyncIncludeTransaction(Guid id, CancellationToken cancellationToken = default)
        => await _context.ReserveTimesReceipt.AsQueryable()
                                        .Include(r => r.TransactionReceipt)
                                        .Include(r => r.TransactionSender)
                                        .Include(r => r.BusinessReceipt)
                                        .Include(r => r.BusinessSender)
                                        .Include(r => r.User)
                                        .AsSplitQuery()
                                        .Where(r => r.Id == id)
                                        .FirstOrDefaultAsync(cancellationToken);
}