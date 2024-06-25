namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTime;


public record UpdateStateReserveTimeReceiptCommandRequest(Guid Id, ReserveState State, bool Finished) : IRequest
{
    public static UpdateStateReserveTimeReceiptCommandRequest Create(Guid id, UpdateStateReserveTimeReceiptDTO model)
        => new(id, model.State, model.Finished);
}

public record UpdateStateReserveTimeReceiptDTO(ReserveState State, bool Finished);
