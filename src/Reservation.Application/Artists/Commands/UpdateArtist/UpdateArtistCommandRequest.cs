namespace Reservation.Application.Artists.Commands.UpdateArtist;

public record UpdateArtistCommandRequest
(
    Guid Id, Guid BusinessId, string Name, string Description,
    string CoverImagePath, bool Active
) : IRequest
{
    public static UpdateArtistCommandRequest Create(Guid id, Guid businessId, UpdateArtistDTO model)
        => new(id, businessId, model.Name, model.Description, model.CoverImagePath, model.Active);
}

public record UpdateArtistDTO
(
    string Name, string Description,
    string CoverImagePath, bool Active
);
