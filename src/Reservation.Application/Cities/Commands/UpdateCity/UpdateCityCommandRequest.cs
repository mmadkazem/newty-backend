namespace Reservation.Application.Cities.Commands.UpdateCity;


public record UpdateCityCommandRequest(int Id, string Name, string State) : IRequest
{
    public static UpdateCityCommandRequest Create(int id, string name, string state)
        => new(id, name, state);
}