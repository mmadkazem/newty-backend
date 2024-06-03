

namespace Reservation.Application.Cities.Commands.CreateCity;


public record CreateCityCommandRequest(string Name, string State) : IRequest;
