namespace Reservation.Application.Artists.Queries.GetArtistByBusinessId;


public record GetArtistByBusinessIdQueryRequest(Guid BusinessId)
    : IRequest<IEnumerable<IResponse>>;
