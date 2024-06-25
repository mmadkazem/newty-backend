
namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTimeSender;


public record UpdateStateReserveTimeSenderCommandRequest(Guid Id, ReserveState State, bool Finished) : IRequest
{
    public static UpdateStateReserveTimeSenderCommandRequest Create(Guid id, UpdateStateReserveTimeSenderDTO model)
        => new(id, model.State, model.Finished);
}

public record UpdateStateReserveTimeSenderDTO(ReserveState State, bool Finished);
