namespace Reservation.Application.Account.Queries.Login;


public record LoginQueryRequest
(
    string Code,
    string PhoneNumber,
    string Role
): IRequest<JwtTokensData>;