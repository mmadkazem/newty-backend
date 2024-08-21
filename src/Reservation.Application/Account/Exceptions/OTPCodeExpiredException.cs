namespace Reservation.Application.Account.Exceptions;


public class OTPCodeExpiredException()
    : NewtyBadRequestBaseException("کد منقضی شده است دوباره کد بگیرید");