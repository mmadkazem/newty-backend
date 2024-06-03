namespace Reservation.Application.Cities.Commands.UpdateCity;


public record UpdateCityCommandRequest(Guid Id, string Name, string State) : IRequest;