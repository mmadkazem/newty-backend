namespace Reservation.Application.ReserveTimes.Exceptions;

public class BusinessNotAccessStateIsConfirmedException()
    : NewtyForbiddenBaseException("شما دسترسی به تایید این وقت ندارید");