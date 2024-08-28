namespace Reservation.Application.ExternalServices.Jwt;

public record JwtTempData(string TempToken)
{
    public static implicit operator string(JwtTempData temp)
        => temp.TempToken;
}
public readonly record struct JwtTokensData(string AccessToken, string RefreshToken);
