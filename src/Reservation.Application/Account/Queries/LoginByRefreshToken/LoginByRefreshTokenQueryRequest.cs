
namespace Reservation.Application.Account.Queries.LoginByRefreshToken;


public record LoginByRefreshTokenQueryRequest(Guid Id, string Role) : IRequest<JwtTokensData>;
