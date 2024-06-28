namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators;

public interface IUserTokenValidatorService
{
    Task ValidateAsync(TokenValidatedContext context);
}

public sealed class UserTokenValidatorService(IUnitOfWork uow) : IUserTokenValidatorService
{
    private readonly IUnitOfWork _uow = uow;

    public async Task ValidateAsync(TokenValidatedContext context)
    {
        var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
        if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
        {
            context.Fail("This is not our issued token. It has no claims.");
            return;
        }

        if (context.SecurityToken is not JsonWebToken accessToken || string.IsNullOrWhiteSpace(accessToken.EncodedToken))
        {
            context.Fail("This Token not valid");
            return;
        }

        var userIdString = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (!Guid.TryParse(userIdString, out Guid userId))
        {
            context.Fail("This is not our issued token. It has no user-id.");
            return;
        }

        var user = await _uow.Users.FindAsync(userId);
        if (user == null || !user.IsActive)
        {
            // user has changed his/her password/roles/stat/IsActive
            context.Fail("This token is expired. Please login again.");
        }
    }
}