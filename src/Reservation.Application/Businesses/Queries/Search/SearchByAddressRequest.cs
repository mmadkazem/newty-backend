namespace Reservation.Application.Businesses.Queries.Search;

public record SearchBusinessQueryRequest(int Page, int Size, string Key, string City) : IRequest<Response>;
