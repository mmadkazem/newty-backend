namespace Reservation.Application.ReserveTimes.Queries.GetUserReserveTimeByState;

public record GetUserReserveTimeByStateQueryRequest(int Page, Guid UserId, ReserveState State)
    : IRequest<IEnumerable<IResponse>>
{
    public static GetUserReserveTimeByStateQueryRequest Create(int page, Guid userId, ReserveState state)
        => new(page, userId, state);
}