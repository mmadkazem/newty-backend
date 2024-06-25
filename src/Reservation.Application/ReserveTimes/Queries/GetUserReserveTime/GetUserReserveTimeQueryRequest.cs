namespace Reservation.Application.ReserveTimes.Queries.GetUserReserveTime;


public record GetUserReserveTimeQueryRequest(int Page, Guid UserId, bool Finished)
    : IRequest<IEnumerable<IResponse>>
{
    public static GetUserReserveTimeQueryRequest Create(int page, Guid businessId, bool finished)
        => new(page, businessId, finished);
}
