namespace Reservation.Application.ReserveTimes.Queries.GetUserReserveTimeByState;

public record GetUserReserveTimeByStateQueryRequest(int Page, int Size, Guid UserId, ReserveState State)
    : IRequest<Response>;