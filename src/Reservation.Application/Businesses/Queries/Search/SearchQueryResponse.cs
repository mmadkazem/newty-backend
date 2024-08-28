namespace Reservation.Application.Businesses.Queries.Search;

public record SearchBusinessQueryResponse(Guid Id, string Name, string Address, string City) : IResponse;
