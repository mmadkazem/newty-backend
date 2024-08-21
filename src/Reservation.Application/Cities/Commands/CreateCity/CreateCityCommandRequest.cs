

namespace Reservation.Application.Cities.Commands.CreateCity;


public record CreateCityCommandRequest(string Name, string Key, List<string> Alternatives) : IRequest;
