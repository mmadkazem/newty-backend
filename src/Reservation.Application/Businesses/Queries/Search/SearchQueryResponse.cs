namespace Reservation.Application.Businesses.Queries.Search;

public record SearchQueryResponse(Guid Id, string Name, string Address, string City) : IResponse;
