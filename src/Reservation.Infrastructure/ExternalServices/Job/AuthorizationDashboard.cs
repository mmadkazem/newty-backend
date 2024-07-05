using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Reservation.Infrastructure.ExternalServices.Job;

public sealed class AuthorizationDashboard : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        if (!httpContext.User.Identity.IsAuthenticated)
        {
            return false;
        }
        if (!httpContext.User.IsInRole(Role.Admin))
        {
            return false;
        }
        return true;
    }
}