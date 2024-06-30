namespace Reservation.Application.ReserveTimes.Exceptions;


public class UserNotAccessStateIsConfirmedException()
    : ReservationBadRequestBaseException("کاربر می تواند لغو کند");
