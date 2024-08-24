
namespace Reservation.Application.Account.Commands.UpdateUser;

public record UpdateUserCommandRequest(Guid Id, string FullName, string PhoneNumber, string City) : IRequest;
public readonly record struct UpdateUserDTO(string FullName, string PhoneNumber, string City);
