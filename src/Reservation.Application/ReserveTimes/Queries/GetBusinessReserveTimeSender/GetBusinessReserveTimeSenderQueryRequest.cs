namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeSender;


public record GetBusinessReserveTimeSenderQueryRequest(int Page, bool Finished, Guid BusinessId)
    : IRequest<IEnumerable<IResponse>>
{
    public static GetBusinessReserveTimeSenderQueryRequest Create(int page, bool finished, Guid businessId)
        => new(page, finished, businessId);
}
