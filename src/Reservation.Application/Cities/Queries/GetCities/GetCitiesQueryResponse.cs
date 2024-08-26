namespace Reservation.Application.Cities.Queries.GetCities;

public record GetCitiesQueryResponse
(
    int Id, string FaName,
    IEnumerable<string> Alternatives,
    string Key
) : IResponse;
