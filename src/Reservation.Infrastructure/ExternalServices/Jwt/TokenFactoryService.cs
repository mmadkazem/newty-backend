using Reservation.Share;

namespace Reservation.Infrastructure.ExternalServices.Jwt;


public sealed class TokenFactoryService(IOptions<TempTokenOption> optionTemp,
        IOptions<UserTokenOption> optionUser,
        IOptions<BusinessTokenOption> optionBusiness,
        IOptions<RefreshTokenOption> optionsRefresh,
        IOptions<AdminTokenOption> optionsAdmin)
    : ITokenFactoryService
{
    private readonly IOptions<TempTokenOption> _optionTemp = optionTemp;
    private readonly IOptions<UserTokenOption> _optionUser = optionUser;
    private readonly IOptions<BusinessTokenOption> _optionBusiness = optionBusiness;
    private readonly IOptions<RefreshTokenOption> _optionsRefresh = optionsRefresh;
    private readonly IOptions<AdminTokenOption> _optionsAdmin = optionsAdmin;

    public JwtTempData CreateTempToken(string code, string phoneNumber, string role)
    {
        var claims = new List<Claim>
        {
            // Add Role (Business or User or Admin)
            new(ClaimTypes.Role, role, ClaimValueTypes.String, _optionTemp.Value.Issuer),
            // Issuer
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iss, _optionTemp.Value.Issuer, ClaimValueTypes.String, _optionTemp.Value.Issuer),
            // Issued at
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _optionTemp.Value.Issuer),
            // Serial Number at
            new(ClaimTypes.SerialNumber, code, "Code", _optionTemp.Value.Issuer),
            // custom data
            new(ClaimTypes.UserData, phoneNumber, "PhoneNumber", _optionTemp.Value.Issuer)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionTemp.Value.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken
        (
            issuer: _optionTemp.Value.Issuer,
            audience: _optionTemp.Value.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_optionTemp.Value.TempTokenExpirationMinutes),
            signingCredentials: creds
        );
        var tempToken = new JwtSecurityTokenHandler().WriteToken(token);
        return new(tempToken);
    }

    public JwtTokensData CreateUserToken(User user)
    {
        var accessToken = createUserAccessToken(user);
        var refreshToken = createRefreshToken(user.Id, Role.User);
        return new(accessToken, refreshToken);
    }
    public JwtTokensData CreateBusinessToken(Business business)
    {
        var accessToken = createBusinessAccessToken(business);
        var refreshToken = createRefreshToken(business.Id, Role.Business);
        return new(accessToken, refreshToken);
    }

    public JwtTokensData CreateAdminToken(User admin)
    {
        var accessToken = createAdminAccessToken(admin);
        var refreshToken = createRefreshToken(admin.Id, Role.Admin);
        return new(accessToken, refreshToken);
    }

    private string createAdminAccessToken(User admin)
    {
        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, StringUtils.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _optionsAdmin.Value.Issuer),
            // Issuer
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iss, _optionsAdmin.Value.Issuer, ClaimValueTypes.String, _optionsAdmin.Value.Issuer),
            // Issued at
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _optionsAdmin.Value.Issuer),
            new(ClaimTypes.NameIdentifier, admin.Id.ToString(), ClaimValueTypes.String, _optionsAdmin.Value.Issuer),
            // add roles
            new(ClaimTypes.Role, Role.Admin, ClaimValueTypes.String, _optionsAdmin.Value.Issuer)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionsAdmin.Value.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            issuer: _optionsAdmin.Value.Issuer,
            audience: _optionsAdmin.Value.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_optionsAdmin.Value.AccessTokenExpirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private string createRefreshToken(Guid id, string role)
    {
        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, StringUtils.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _optionsRefresh.Value.Issuer),
            // Issuer
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iss, _optionsRefresh.Value.Issuer, ClaimValueTypes.String, _optionsRefresh.Value.Issuer),
            // Issued at
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _optionsRefresh.Value.Issuer),
            // for invalidation
            new(ClaimTypes.SerialNumber, StringUtils.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _optionsRefresh.Value.Issuer),
            // custom data
            new(ClaimTypes.NameIdentifier, id.ToString(), ClaimValueTypes.String, _optionsRefresh.Value.Issuer),
            // add roles
            new(ClaimTypes.Role, role, ClaimValueTypes.String, _optionsRefresh.Value.Issuer)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionsRefresh.Value.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            issuer: _optionsRefresh.Value.Issuer,
            audience: _optionsRefresh.Value.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_optionsRefresh.Value.RefreshTokenExpirationMinutes),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private string createUserAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, StringUtils.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _optionUser.Value.Issuer),
            // Issuer
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iss, _optionUser.Value.Issuer, ClaimValueTypes.String, _optionUser.Value.Issuer),
            // Issued at
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _optionUser.Value.Issuer),
            new(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String, _optionUser.Value.Issuer),
            // custom data
            new(ClaimTypes.UserData, user.PhoneNumber, ClaimValueTypes.String, _optionUser.Value.Issuer),
            // add roles
            new(ClaimTypes.Role, Role.User, ClaimValueTypes.String, _optionUser.Value.Issuer)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionUser.Value.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            issuer: _optionUser.Value.Issuer,
            audience: _optionUser.Value.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_optionUser.Value.AccessTokenExpirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private string createBusinessAccessToken(Business business)
    {
        var claims = new List<Claim>
        {
            // Unique Id for all Jwt tokes
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, StringUtils.CreateCryptographicallySecureGuid(), ClaimValueTypes.String, _optionBusiness.Value.Issuer),
            // Issuer
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iss, _optionBusiness.Value.Issuer, ClaimValueTypes.String, _optionBusiness.Value.Issuer),
            // Issued at
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _optionBusiness.Value.Issuer),
            new(ClaimTypes.NameIdentifier, business.Id.ToString(), ClaimValueTypes.String, _optionBusiness.Value.Issuer),
            // custom data
            new(ClaimTypes.UserData, business.PhoneNumber, ClaimValueTypes.String, _optionBusiness.Value.Issuer),
            // add roles
            new(ClaimTypes.Role, Role.Business, ClaimValueTypes.String, _optionBusiness.Value.Issuer)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionBusiness.Value.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            issuer: _optionBusiness.Value.Issuer,
            audience: _optionBusiness.Value.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_optionBusiness.Value.AccessTokenExpirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}