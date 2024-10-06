namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTime;

public sealed record CreateReserveTimeReceiptCommandRequest
(
    Guid UserId, Guid BusinessId,
    DateTime DateTime,
    IEnumerable<ArtistService> ArtistServices
) : IRequest
{
    public static CreateReserveTimeReceiptCommandRequest Create(Guid userId, CreateReserveTimeReceiptDTO model)
        => new(userId, model.BusinessId, model.DateTime, model.ArtistServices);
}
public sealed record ArtistService(Guid ArtistId, Guid ServiceId);
public record CreateReserveTimeReceiptDTO
(
    Guid BusinessId,
    DateTime DateTime,
    IEnumerable<ArtistService> ArtistServices
);
