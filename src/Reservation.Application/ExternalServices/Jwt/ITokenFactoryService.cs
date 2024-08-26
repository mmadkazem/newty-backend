namespace Reservation.Application.ExternalServices.Jwt;

public interface ITokenFactoryService
{
    JwtTempData CreateTempToken(string code, string phoneNumber, string role);
    JwtTokensData CreateBearerToken(Guid id, string role, string phoneNumber, string? name = null);
}

