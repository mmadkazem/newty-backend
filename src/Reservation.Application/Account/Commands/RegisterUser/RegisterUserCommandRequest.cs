namespace Reservation.Application.Account.Commands.RegisterUser;


public record RegisterUserCommandRequest(string FullName, string PhoneNumber) : IRequest;