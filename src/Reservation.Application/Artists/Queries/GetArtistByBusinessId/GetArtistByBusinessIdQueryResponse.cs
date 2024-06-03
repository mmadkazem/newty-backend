namespace Reservation.Application.Artists.Queries.GetArtistByBusinessId;

public record GetArtistByBusinessIdQueryResponse(
    Guid ArtistId, string Name,
    string CoverImagePath,
    bool Active
) : IResponse;