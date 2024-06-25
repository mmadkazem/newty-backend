namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeSender;


public record CreateReserveTimeSenderCommandRequest
(
    Guid BusinessSenderId, Guid BusinessReceiptId,
    IEnumerable<Guid> Services,
    IEnumerable<Guid> Artists, DateTime DateTime
) : IRequest
{
    public static CreateReserveTimeSenderCommandRequest Create(Guid BusinessReceiptId, CreateReserveTimeSenderDTO model)
        => new(BusinessReceiptId, model.BusinessSenderId, model.Services, model.Artists, model.DateTime);
}

public record CreateReserveTimeSenderDTO
(
    Guid BusinessSenderId,
    IEnumerable<Guid> Services,
    IEnumerable<Guid> Artists, DateTime DateTime
);
