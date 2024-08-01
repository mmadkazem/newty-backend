namespace Reservation.Application.Account.Queries.AdminLogin;

public readonly record struct AdminLoginQueryResponse(JwtTokensData Tokens, string Message);