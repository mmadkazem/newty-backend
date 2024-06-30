namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTime;


public record UpdateStateReserveTimeReceiptCommandRequest(Guid Id, ReserveState State, string Role) : IRequest;