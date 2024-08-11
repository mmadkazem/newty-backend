namespace Reservation.Application.ExternalServices.Jwt;

public interface ITokenFactoryService
{
    JwtTempData CreateTempToken(string code, string phoneNumber, string role);
    JwtTokensData CreateUserToken(Guid userId);
    JwtTokensData CreateBusinessToken(Guid businessId);
    JwtTokensData CreateAdminToken(Guid adminId);
}

