namespace Reservation.Application.Artists.Commands.UpdateArtist;

public record UpdateArtistCommandRequest
(
    Guid Id, string Name, string Description,
    string CoverImagePath, bool Active
) : IRequest
{
    public static UpdateArtistCommandRequest Create(Guid Id, UpdateArtistDTO model)
        => new(Id, model.Name, model.Description, model.CoverImagePath, model.Active);
}

public record UpdateArtistDTO
(
    string Name, string Description,
    string CoverImagePath, bool Active
);
