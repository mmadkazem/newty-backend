using Reservation.Application.Businesses.Queries.GetBusinessById;
using Reservation.Application.Businesses.Queries.GetBusinessesWaitingValid;
using Reservation.Application.Common.DTOs;

namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class BusinessRepository(NewtyDbContext context, NewtyDbContextCommand contextCommand)
    : IBusinessRepository
{
    private readonly NewtyDbContext _context = context;
    private readonly NewtyDbContextCommand _contextCommand = contextCommand;

    public void Add(Business business)
        => _contextCommand.Businesses.Add(business);

    public void AddUserVIP(UserVIP userVIP)
        => _contextCommand.UsersVIP.Add(userVIP);


    public async Task<bool> AnyAsync(string phoneNumber, CancellationToken cancellationToken)
        => await _contextCommand.Businesses.AsQueryable()
                                    .AnyAsync(b => b.PhoneNumber == phoneNumber, cancellationToken);

    public async Task<bool> AnyAsync(Guid businessId, CancellationToken cancellationToken = default)
        => await _contextCommand.Businesses.AsQueryable()
                                    .AnyAsync(b => b.Id == businessId, cancellationToken);

    public async Task<Business> FindAsync(Guid id, CancellationToken cancellationToken = default)
        => await _contextCommand.Businesses.AsQueryable()
                                    .Where(b => b.Id == id)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Business> FindAsyncByIncludePoints(Guid businessId, CancellationToken cancellationToken)
        => await _contextCommand.Businesses.AsQueryable()
                                    .Include(b => b.Points)
                                    .Where(b => b.Id == businessId)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Business> FindAsyncByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        => await _contextCommand.Businesses.AsQueryable()
                                    .Where(b => b.PhoneNumber == phoneNumber)
                                    .FirstOrDefaultAsync(cancellationToken);

    public async Task<Business> FindAsyncIncludeSMSCredit(Guid id, CancellationToken cancellationToken = default)
        => await _contextCommand.Businesses.AsQueryable()
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
                                        b.City.FaName,
                                        b.Holidays,
                                        new Time(b.StartHoursOfWor.Hours, b.StartHoursOfWor.Minutes),
                                        new Time(b.EndHoursOfWor.Hours, b.EndHoursOfWor.Minutes),
                                        b.IsCancelReserveTime
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