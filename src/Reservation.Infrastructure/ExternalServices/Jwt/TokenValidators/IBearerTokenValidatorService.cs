namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators;

public interface IBearerTokenValidatorService
{
    Task ValidateAsync(TokenValidatedContext context);
}

public sealed class UserTokenValidatorService : IBearerTokenValidatorService
{
    // private readonly IUnitOfWork _uow;

    // public UserTokenValidatorService(IUnitOfWork uow)
    // {
    //     _uow = uow;
    // }

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
        await Task.CompletedTask;
        // var role = claimsIdentity.FindFirst(ClaimTypes.Role).Value;
        // if (!(role== Role.Business))
        // {
        //     var user = await _uow.Users.FindAsync(id);
        //     if (user == null || !user.IsActive)
        //     {
        //         // user has changed his/her password/roles/stat/IsActive
        //         context.Fail("این توکن منقضی شده است. لطفا دوباره وارد شوید.");
        //         return;
        //     }

        //     if (user.Role != role)
        //     {
        //         context.Fail("شما به این سرویس دسترسی ندارید");
        //         return;
        //     }
        // }
        // else
        // {
        //     var business = await _uow.Businesses.FindAsync(id);
        //     if (business == null || !business.IsActive)
        //     {
        //         // user has changed his/her password/roles/stat/IsActive
        //         context.Fail("این توکن منقضی شده است. لطفا دوباره وارد شوید.");
        //         return;
        //     }
        //     if (business.State != BusinessState.Valid)
        //     {
        //         context.Fail("لطفا اطلاعات را تکمیل کنید");
        //         return;
        //     }
        // }
    }
}