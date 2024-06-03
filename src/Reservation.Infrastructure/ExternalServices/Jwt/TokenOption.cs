namespace Reservation.Infrastructure.ExternalServices.Jwt;

public class TempTokenOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int TempTokenExpirationMinutes { get; set; }
    public string Key { get; set; }
}

public class UserTokenOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpirationMinutes { get; set; }
    public string Key { get; set; }
}

public class BusinessTokenOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpirationMinutes { get; set; }
    public string Key { get; set; }
}

public class RefreshTokenOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int RefreshTokenExpirationMinutes { get; set; }
    public string Key { get; set; }
}