namespace Reservation.Application.Artists.Queries.GetArtistServices;


public sealed record GetArtistServicesQueryRequest(Guid ArtistId) : IRequest<IEnumerable<IResponse>>;
