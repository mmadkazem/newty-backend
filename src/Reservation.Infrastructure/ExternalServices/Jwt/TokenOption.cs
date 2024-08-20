namespace Reservation.Infrastructure.ExternalServices.Jwt;

public class TokenOption
{
    public TempTokenOption TempTokenOption { get; set; }
    public BearerTokenOption BearerTokenOption { get; set; }
    public RefreshTokenOption RefreshTokenOption { get; set; }
}

public sealed class TempTokenOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int TempTokenExpirationMinutes { get; set; }
}

public sealed class BearerTokenOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpirationMinutes { get; set; }
}
public sealed class RefreshTokenOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int RefreshTokenExpirationMinutes { get; set; }
}