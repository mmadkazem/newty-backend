namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators;


public interface ITempTokenValidatorService
{
    Task ValidateAsync(TokenValidatedContext context);
}

public sealed class TempTokenValidatorService(IUnitOfWork uow) : ITempTokenValidatorService
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

        var code = claimsIdentity.FindFirst(ClaimTypes.SerialNumber).Value;

        if (code == string.Empty)
        {
            context.Fail("This token does not code");
            return;
        }

        if (context.SecurityToken is not JsonWebToken accessToken || string.IsNullOrWhiteSpace(accessToken.EncodedToken))
        {
            context.Fail("This Token not valid");
            return;
        }
        await Task.CompletedTask;
    }
}