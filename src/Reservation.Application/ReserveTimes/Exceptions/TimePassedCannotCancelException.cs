namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class TimePassedCannotCancelException()
    : NewtyBadRequestBaseException("نمی توانید کنسل کنید زیرا از بازه ی زمانی تعیین کنسل گذشته است");