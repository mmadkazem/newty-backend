namespace Reservation.Application.Cities.Commands.RemoveCity;


public sealed record RemoveCityCommandRequest(Guid Id) : IRequest;
