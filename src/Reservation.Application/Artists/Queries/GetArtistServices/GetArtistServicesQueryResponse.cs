namespace Reservation.Application.Artists.Queries.GetArtistServices;

public record GetArtistServicesQueryResponse
(
    Guid ServiceId, string Name,
    TimeOnly Time, int Price, bool Active
) : IResponse;