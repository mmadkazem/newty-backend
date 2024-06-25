namespace Reservation.Application.ReserveTimes.Queries.GetFreeTime;

public record GetFreeTimeQueryRequest(Guid BusinessId) : IRequest<IEnumerable<IResponse>>;

public record GetFreeTimeQueryResponse(DateTime StartFreeTime, DateTime EndFreeTime) : IResponse;
