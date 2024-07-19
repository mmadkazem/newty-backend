namespace Reservation.Application.Cities.Commands.UpdateCity;


public record UpdateCityCommandRequest(Guid Id, string Name, string State) : IRequest
{
    public static UpdateCityCommandRequest Create(Guid id, string name, string state)
        => new(id, name, state);
}