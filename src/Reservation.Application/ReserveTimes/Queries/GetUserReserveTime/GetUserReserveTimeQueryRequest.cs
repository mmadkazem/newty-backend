namespace Reservation.Application.ReserveTimes.Queries.GetUserReserveTime;


public record GetUserReserveTimeQueryRequest(int Page, int Size, Guid UserId, bool Finished)
    : IRequest<Response>;
