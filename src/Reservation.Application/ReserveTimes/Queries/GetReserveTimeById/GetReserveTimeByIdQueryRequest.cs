namespace Reservation.Application.ReserveTimes.Queries.GetReserveTimeById;

public record GetReserveTimeByIdReceiptQueryRequest(Guid Id) : IRequest<IResponse>;