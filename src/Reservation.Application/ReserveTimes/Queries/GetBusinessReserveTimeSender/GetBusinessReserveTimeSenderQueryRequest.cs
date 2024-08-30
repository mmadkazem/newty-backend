namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeSender;


public record GetBusinessReserveTimeSenderQueryRequest(int Page, int Size, bool Finished, Guid BusinessId)
    : IRequest<Response>;