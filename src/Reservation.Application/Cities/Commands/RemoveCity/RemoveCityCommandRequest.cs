namespace Reservation.Application.Cities.Commands.RemoveCity;


public sealed record RemoveCityCommandRequest(int Id) : IRequest;
