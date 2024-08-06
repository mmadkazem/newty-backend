namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTimeSender;


public record UpdateStateReserveTimeSenderCommandRequest(Guid Id, Guid BusinessId, ReserveState State)
    : IRequest<UpdateStateReserveTimeSenderCommandResponse>;

public readonly record struct UpdateStateReserveTimeSenderCommandResponse(string Message);
