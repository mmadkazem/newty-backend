namespace Reservation.Application.Businesses.Commands.RegisterBusiness;


public record RegisterBusinessCommandRequest(string PhoneNumber, string City) : IRequest;