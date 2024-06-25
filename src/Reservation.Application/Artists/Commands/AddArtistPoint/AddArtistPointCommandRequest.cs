namespace Reservation.Application.Artists.Commands.AddArtistPoint;


public record AddArtistPointCommandRequest(Guid UserId, Guid ArtistId, int Rate) : IRequest
{
    public static AddArtistPointCommandRequest Create(Guid userId, AddArtistPointDTO model)
        => new(userId, model.ArtistId, model.Rate);
}
public record AddArtistPointDTO(Guid ArtistId, int Rate);
