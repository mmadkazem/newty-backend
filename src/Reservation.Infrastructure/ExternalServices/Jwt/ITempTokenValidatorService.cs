namespace Reservation.Infrastructure.ExternalServices.Jwt;


public interface ITempTokenValidatorService
{
    void ValidateAsync(TokenValidatedContext context);
}

public class TempTokenValidatorService(IUnitOfWork uow) : ITempTokenValidatorService
{
    private readonly IUnitOfWork _uow = uow;

    public void ValidateAsync(TokenValidatedContext context)
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

        var accessToken = context.SecurityToken as JsonWebToken;
        if (accessToken == null || string.IsNullOrWhiteSpace(accessToken.EncodedToken))
        {
            context.Fail("This Token not valid");
            return;
        }
    }
}