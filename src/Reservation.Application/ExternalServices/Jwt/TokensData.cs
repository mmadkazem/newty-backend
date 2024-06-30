namespace Reservation.Application.ExternalServices.Jwt;

public record JwtTempData(string TempToken)
{
    public static implicit operator string(JwtTempData temp)
        => temp.TempToken;
}
public record JwtTokensData(string AccessToken, string RefreshToken);
