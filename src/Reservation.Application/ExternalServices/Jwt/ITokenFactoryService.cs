namespace Reservation.Application.ExternalServices.Jwt;

public interface ITokenFactoryService
{
    JwtTempData CreateTempToken(string code, string phoneNumber, string role);
    JwtTokensData CreateUserToken(User user);
    JwtTokensData CreateBusinessToken(Business business);
}

