namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeByState;
public record GetBusinessReserveTimeByStateReceiptQueryRequest(int Page, int Size, ReserveState State, Guid BusinessId)
    : IRequest<Response>;
