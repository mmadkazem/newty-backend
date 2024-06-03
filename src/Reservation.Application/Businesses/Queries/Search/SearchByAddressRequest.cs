namespace Reservation.Application.Businesses.Queries.Search;

public record SearchBusinessRequest(int Page, string Key) : IRequest<IEnumerable<IResponse>>;
