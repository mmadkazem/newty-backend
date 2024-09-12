namespace Reservation.Infrastructure.ExternalServices.Jwt.TokenValidators.Exceptions;

public sealed class RoleInvalidException()
    : NewtyUnAuthorizeBaseException("شما به این سرویس دسترسی ندارید");
