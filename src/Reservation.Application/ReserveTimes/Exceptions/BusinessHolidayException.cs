namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class BusinessHolidayException()
    : NewtyBadRequestBaseException("این وقت در روز تعطیل کسب و کار است");