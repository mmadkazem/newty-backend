namespace Reservation.Application.Artists.Queries.GetArtist;

public record GetArtistQueryResponse
(
    Guid ArtistId, string Name,
    string Description, string CoverImagePath,
    bool Active
) : IResponse;