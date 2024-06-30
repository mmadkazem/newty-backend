namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeSender;


public record CreateReserveTimeSenderCommandRequest
(
    Guid BusinessSenderId, Guid BusinessReceiptId,
    DateTime DateTime,
    IEnumerable<ArtistService> ArtistServices
) : IRequest
{
    public static CreateReserveTimeSenderCommandRequest Create(Guid BusinessSenderId, CreateReserveTimeSenderDTO model)
        => new(BusinessSenderId, model.BusinessReceiptId, model.DateTime, model.ArtistServices);
}
public record ArtistService(Guid ArtistId, Guid ServiceId);

public record CreateReserveTimeSenderDTO
(
    Guid BusinessReceiptId,
    DateTime DateTime,
    IEnumerable<ArtistService> ArtistServices
);
