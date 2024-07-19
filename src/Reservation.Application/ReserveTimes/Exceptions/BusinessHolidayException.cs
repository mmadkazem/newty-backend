namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class BusinessHolidayException()
    : ReservationBadRequestBaseException("این وقت در روز تعطیل کسب و کار است");