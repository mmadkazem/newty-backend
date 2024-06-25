namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTime;

public record CreateReserveTimeReceiptCommandRequest
(
    Guid UserId, Guid BusinessId,
    IEnumerable<Guid> Services,
    IEnumerable<Guid> Artists, DateTime DateTime
) : IRequest
{
    public static CreateReserveTimeReceiptCommandRequest Create(Guid userId, CreateReserveTimeReceiptDTO model)
        => new(userId, model.BusinessId, model.Services, model.Artists, model.DateTime);
}

public record CreateReserveTimeReceiptDTO
(
    Guid BusinessId,
    IEnumerable<Guid> Services,
    IEnumerable<Guid> Artists, DateTime DateTime
);
