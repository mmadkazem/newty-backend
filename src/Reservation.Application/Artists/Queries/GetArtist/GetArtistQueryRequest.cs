namespace Reservation.Application.Artists.Queries.GetArtist;


public record GetArtistQueryRequest(Guid ArtistId) : IRequest<IResponse>;
