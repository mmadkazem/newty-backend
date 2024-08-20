namespace Reservation.Application.Cities.Queries.GetCities;

public record GetCitiesQueryResponse
(
    Guid Id, string FaName,
    IEnumerable<string> Alternatives,
    string Key
) : IResponse;
