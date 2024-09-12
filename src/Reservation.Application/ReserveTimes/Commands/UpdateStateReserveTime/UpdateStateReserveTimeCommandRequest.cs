namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTime;


public record UpdateStateReserveTimeReceiptCommandRequest(Guid Id, ReserveState State, string Role, Guid CallId)
    : IRequest<UpdateStateReserveTimeReceiptCommandResponse>;

public readonly record struct UpdateStateReserveTimeReceiptCommandResponse(string Message);