namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators;


public interface IBusinessTokenValidatorService
{
    Task ValidateAsync(TokenValidatedContext context);
}

public sealed class BusinessTokenValidatorService(IUnitOfWork uow) : IBusinessTokenValidatorService
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

        var businessIdString = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (!Guid.TryParse(businessIdString, out Guid businessId))
        {
            context.Fail("This is not our issued token. It has no user-id.");
            return;
        }

        var business = await _uow.Businesses.FindAsync(businessId);
        if (business == null || !business.IsActive)
        {
            // user has changed his/her password/roles/stat/IsActive
            context.Fail("This token is expired. Please login again.");
        }
    }
}