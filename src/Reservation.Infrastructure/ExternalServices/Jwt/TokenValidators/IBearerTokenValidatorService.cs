namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators;

public interface IBearerTokenValidatorService
{
    Task ValidateAsync(TokenValidatedContext context);
}

public sealed class UserTokenValidatorService : IBearerTokenValidatorService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public UserTokenValidatorService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

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
        using var serviceScope = _scopeFactory.CreateScope();
        using var _context = serviceScope.ServiceProvider.GetService<NewtyDbContext>();

        var role = claimsIdentity.FindFirst(ClaimTypes.Role).Value;
        if (!(role == Role.Business))
        {
            var user = await _context.Users.AsQueryable().FirstOrDefaultAsync(u => u.Id == id);
            if (user is null || !user.IsActive)
            {
                // user has changed his/her password/roles/stat/IsActive
                context.Fail("این توکن منقضی شده است. لطفا دوباره وارد شوید.");
                return;
            }

            if (user.Role != role)
            {
                context.Fail("شما به این سرویس دسترسی ندارید");
                return;
            }
        }
        else
        {
            var business = await _context.Businesses.AsQueryable().FirstOrDefaultAsync(u => u.Id == id);
            if (business is null || !business.IsActive)
            {
                // user has changed his/her password/roles/stat/IsActive
                context.Fail("این توکن منقضی شده است. لطفا دوباره وارد شوید.");
                return;
            }
            if (business.State != BusinessState.Valid)
            {
                context.Fail("لطفا اطلاعات را تکمیل کنید یا منتظر تایید کارشناسان ما باشید");
                return;
            }
        }
    }
}