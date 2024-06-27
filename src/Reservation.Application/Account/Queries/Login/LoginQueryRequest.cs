namespace Reservation.Application.Account.Queries.Login;


public record LoginQueryRequest
(
    string CodeActual,
    string CodeExpected,
    string PhoneNumber,
    string Role
): IRequest<JwtTokensData>;