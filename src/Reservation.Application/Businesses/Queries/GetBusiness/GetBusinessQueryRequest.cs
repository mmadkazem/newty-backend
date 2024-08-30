namespace Reservation.Application.Businesses.Queries.GetBusiness;


public sealed record GetBusinessQueryRequest(Guid BusinessId) : IRequest<IResponse>;

public sealed record GetBusinessQueryResponse
(
    Guid Id, string PhoneNumber, string Name, string CoverImagePath,
    string ParvaneKasbImagePath, string Description, string Address, string City,
    IEnumerable<DayOfWeek> Holidays, Time StartHoursOfWork, Time EndHoursOfWork,
    bool IsCancelReserveTime
) : IResponse;
