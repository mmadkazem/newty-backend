namespace Reservation.Application.Artists.Commands.CreateArtist;


public record CreateArtistCommandRequest
(
    string Name,
    string CoverImagePath,
    string Description,
    Guid BusinessId
) : IRequest
{
    public static CreateArtistCommandRequest Create(Guid businessId, CreateArtistDTO model)
        => new(model.Name, model.CoverImagePath, model.Description, businessId);
}

public record CreateArtistDTO
(
    string Name,
    string CoverImagePath,
    string Description
);
