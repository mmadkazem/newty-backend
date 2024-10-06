namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeWithDirectPayment;


public sealed record CreateReserveTimeWithDirectPaymentCommandRequest
(
    Guid UserId, Guid BusinessId,
    DateTime DateTime,
    IEnumerable<ArtistService> ArtistServices
) : IRequest<string>
{
    public static CreateReserveTimeWithDirectPaymentCommandRequest Create(Guid userId, CreateReserveTimeWithDirectPaymentDTO model)
        => new(userId, model.BusinessId, model.DateTime, model.ArtistServices);
}

public sealed record CreateReserveTimeWithDirectPaymentDTO
(
    Guid BusinessId,
    DateTime DateTime,
    IEnumerable<ArtistService> ArtistServices
);