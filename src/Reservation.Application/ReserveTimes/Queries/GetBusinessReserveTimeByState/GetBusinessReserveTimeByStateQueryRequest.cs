namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeByState;
public record GetBusinessReserveTimeByStateReceiptQueryRequest(int Page, ReserveState State, Guid BusinessId)
    : IRequest<IEnumerable<IResponse>>
{
    public static GetBusinessReserveTimeByStateReceiptQueryRequest Create(int page, ReserveState state, Guid businessId)
        => new(page, state, businessId);
}
