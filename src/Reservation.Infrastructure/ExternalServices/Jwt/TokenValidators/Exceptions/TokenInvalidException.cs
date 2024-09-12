namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators.Exceptions;

public sealed class TokenInvalidException()
    : NewtyUnAuthorizeBaseException("این توکن معتبر نیست");
