namespace Reservation.Application.Account.Queries.Login;


public record LoginCommandRequest(string CodeActual, string CodeExpected, string PhoneNumber, string Role) : IRequest<JwtTokensData>;