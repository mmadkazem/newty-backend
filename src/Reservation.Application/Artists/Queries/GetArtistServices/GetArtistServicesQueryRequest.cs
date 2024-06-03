
namespace Reservation.Application.Artists.Queries.GetArtistServices;


public record GetArtistServicesQueryRequest(Guid ArtistId) : IRequest<IEnumerable<IResponse>>;
