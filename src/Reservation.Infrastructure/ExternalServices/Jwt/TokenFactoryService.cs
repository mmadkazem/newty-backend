using Reservation.Share;

namespace Reservation.Infrastructure.ExternalServices.Jwt;


public sealed class TokenFactoryService(IOptions<TokenOption> options) : ITokenFactoryService
{
    private readonly TempTokenOption _optionTemp = options.Value.TempTokenOption;
    private readonly BearerTokenOption _optionBearer = options.Value.BearerTokenOption;
    private readonly RefreshTokenOption _optionsRefresh = options.Value.RefreshTokenOption;

    public JwtTempData CreateTempToken(string code, string phoneNumber, string role)
    {
        var claims = new List<Claim>
        {
            // Add Role (Business or User or Admin)
            new(ClaimTypes.Role, role, ClaimValueTypes.String, _optionTemp.Issuer),
            // Issuer
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iss, _optionTemp.Issuer, ClaimValueTypes.String, _optionTemp.Issuer),
            // Issued at
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _optionTemp.Issuer),
            // Serial Number at
            new(ClaimTypes.SerialNumber, code, ClaimValueTypes.String, _optionTemp.Issuer),
            // custom data
            new(ClaimTypes.UserData, phoneNumber, ClaimValueTypes.String, _optionTemp.Issuer)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionTemp.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken
        (
            issuer: _optionTemp.Issuer,
            audience: _optionTemp.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_optionTemp.TempTokenExpirationMinutes),
            signingCredentials: creds
        );
        var tempToken = new JwtSecurityTokenHandler().WriteToken(token);
        return new(tempToken);
    }

    public JwtTokensData CreateBearerToken(Guid id, string role, string phoneNumber, string name)
    {
        var accessToken = CreateBearerAccessToken(id, role, phoneNumber, name);
        var refreshToken = CreateRefreshToken(id, role);
        return new(accessToken, refreshToken);
    }

    private string CreateBearerAccessToken(Guid id, string role, string phoneNumber, string name)
    {
        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, StringUtils.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _optionBearer.Issuer),
            // Issuer
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iss, _optionBearer.Issuer, ClaimValueTypes.String, _optionBearer.Issuer),
            // Issued at
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _optionBearer.Issuer),
            // User Costume Data
            new(ClaimTypes.NameIdentifier, id.ToString(), ClaimValueTypes.String, _optionBearer.Issuer),
            new("PhoneNumber", phoneNumber, ClaimValueTypes.String, _optionBearer.Issuer),
            new("Name", name, ClaimValueTypes.String, _optionBearer.Issuer),
            // add roles
            new(ClaimTypes.Role, role, ClaimValueTypes.String, _optionBearer.Issuer)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionBearer.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            issuer: _optionBearer.Issuer,
            audience: _optionBearer.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_optionBearer.AccessTokenExpirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private string CreateRefreshToken(Guid id, string role)
    {
        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, StringUtils.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _optionsRefresh.Issuer),
            // Issuer
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iss, _optionsRefresh.Issuer, ClaimValueTypes.String, _optionsRefresh.Issuer),
            // Issued at
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _optionsRefresh.Issuer),
            // for invalidation
            new(ClaimTypes.SerialNumber, StringUtils.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _optionsRefresh.Issuer),
            // custom data
            new(ClaimTypes.NameIdentifier, id.ToString(), ClaimValueTypes.String, _optionsRefresh.Issuer),
            // add roles
            new(ClaimTypes.Role, role, ClaimValueTypes.String, _optionsRefresh.Issuer)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionsRefresh.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            issuer: _optionsRefresh.Issuer,
            audience: _optionsRefresh.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_optionsRefresh.RefreshTokenExpirationMinutes),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}