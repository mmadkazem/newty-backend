namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators.Exceptions;

public sealed class TokenHasNoClaimException()
    : NewtyUnAuthorizeBaseException("این توکن صادر شده ما نیست. هیچ ادعایی ندارد.");