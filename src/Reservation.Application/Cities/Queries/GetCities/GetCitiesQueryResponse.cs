namespace Reservation.Application.Cities.Queries.GetCities;

public record GetCitiesQueryResponse(Guid Id, string Name) : IResponse;
