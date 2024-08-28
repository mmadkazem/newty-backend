namespace Reservation.Application.Businesses.Queries.Search;

public record SearchBusinessQueryRequest(int Page, string Key, string City) : IRequest<IEnumerable<IResponse>>;
