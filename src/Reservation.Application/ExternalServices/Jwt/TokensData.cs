namespace Reservation.Application.ExternalServices.Jwt;

public record JwtTempData(string TempToken);
public record JwtTokensData(string AccessToken, string RefreshToken);
