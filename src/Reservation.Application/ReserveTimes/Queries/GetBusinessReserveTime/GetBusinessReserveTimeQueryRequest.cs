namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTime;


public record GetBusinessReserveTimeReceiptQueryRequest(int Page, int Size, Guid BusinessId, bool Finished)
    : IRequest<Response>;
