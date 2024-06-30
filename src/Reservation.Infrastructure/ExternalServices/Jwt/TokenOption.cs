namespace Reservation.Infrastructure.ExternalServices.Jwt;

public sealed class TempTokenOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int TempTokenExpirationMinutes { get; set; }
}

public sealed class UserTokenOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpirationMinutes { get; set; }
}

public sealed class BusinessTokenOption
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

public sealed class AdminTokenOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpirationMinutes { get; set; }
}