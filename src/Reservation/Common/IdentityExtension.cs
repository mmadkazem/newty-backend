namespace Liaro.Common;

public static class IdentityExtension
{
    public static string UserCode(this ClaimsPrincipal user)
    {
        try
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.FindFirst(ClaimTypes.SerialNumber)?.Value;
            }
            else
                return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public static Guid UserId(this ClaimsPrincipal user)
    {
        try
        {
            if (user.Identity.IsAuthenticated)
            {
                return Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }
            else
                return Guid.Empty;
        }
        catch (Exception)
        {
            return Guid.Empty;
        }
    }
    public static string UserPhoneNumber(this ClaimsPrincipal user)
    {
        try
        {
            if (user.Identity.IsAuthenticated)
            {
                var sub = user.FindFirst(ClaimTypes.UserData).Value;
                return sub;
            }
            else
                return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public static string Roles(this ClaimsPrincipal user)
    {
        if (user.Identity.IsAuthenticated)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            return claimsIdentity.Claims.Where(x => x.Type == ClaimTypes.Role)
                                        .Select(x => x.Value)
                                        .FirstOrDefault();
        }
        else
            return null;
    }

    public static string UserName(this ClaimsPrincipal user)
    {
        return user.Identity.Name;
    }
}