namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators;

public interface IBearerTokenValidatorService
{
    Task ValidateAsync(TokenValidatedContext context);
}

public sealed class UserTokenValidatorService(IUnitOfWork uow) : IBearerTokenValidatorService
{
    private readonly IUnitOfWork _uow = uow;

    public async Task ValidateAsync(TokenValidatedContext context)
    {
        var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
        if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
        {
            context.Fail("این توکن صادر شده ما نیست. هیچ ادعایی ندارد.");
            return;
        }

        if (context.SecurityToken is not JsonWebToken accessToken || string.IsNullOrWhiteSpace(accessToken.EncodedToken))
        {
            context.Fail("این توکن معتبر نیست");
            return;
        }

        var idString = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (!Guid.TryParse(idString, out Guid id))
        {
            context.Fail("این توکن صادر شده ما نیست. هیچ شناسه کاربری ندارد.");
            return;
        }

        if (!(claimsIdentity.RoleClaimType == Role.Business))
        {
            var user = await _uow.Users.FindAsync(id);
            if (user == null || !user.IsActive)
            {
                // user has changed his/her password/roles/stat/IsActive
                context.Fail("این توکن منقضی شده است. لطفا دوباره وارد شوید.");
            }

            if (user.Role != claimsIdentity.RoleClaimType)
            {
                context.Fail("شما به این سرویس دسترسی ندارید");
            }
        }
        else
        {
            var business = await _uow.Businesses.FindAsync(id);
            if (business == null || !business.IsActive)
            {
                // user has changed his/her password/roles/stat/IsActive
                context.Fail("این توکن منقضی شده است. لطفا دوباره وارد شوید.");
            }
            if (business.State != BusinessState.Valid)
            {
                context.Fail("لطفا اطلاعات را تکمیل کنید");
            }
        }
    }
}