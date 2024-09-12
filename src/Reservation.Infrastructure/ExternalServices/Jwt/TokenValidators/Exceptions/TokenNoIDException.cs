namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators.Exceptions;

public sealed class TokenNoIDException()
    : NewtyUnAuthorizeBaseException("این توکن صادر شده ما نیست. هیچ شناسه کاربری ندارد.");
