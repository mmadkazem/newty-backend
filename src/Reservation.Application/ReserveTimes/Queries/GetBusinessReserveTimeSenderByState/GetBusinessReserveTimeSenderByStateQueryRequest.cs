
namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeSenderByState;

public record GetBusinessReserveTimeSenderByStateQueryRequest(int Page, int Size, ReserveState State, Guid BusinessId)
    : IRequest<Response>;
