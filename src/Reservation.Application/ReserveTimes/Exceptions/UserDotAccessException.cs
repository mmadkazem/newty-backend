namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class DotAccessReserveTimeException()
    : NewtyForbiddenBaseException("شما به این وقت دسترسی ندارید");