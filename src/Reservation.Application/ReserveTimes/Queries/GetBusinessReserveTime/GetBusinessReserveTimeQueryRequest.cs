namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTime;


public record GetBusinessReserveTimeReceiptQueryRequest(int Page, Guid BusinessId, bool Finished)
    : IRequest<IEnumerable<IResponse>>
{
    public static GetBusinessReserveTimeReceiptQueryRequest Create(int page, Guid businessId, bool finished)
        => new(page, businessId, finished);
}
