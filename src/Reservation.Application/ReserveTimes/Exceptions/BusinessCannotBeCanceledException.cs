namespace Reservation.Application.ReserveTimes.Exceptions;

public class BusinessCannotBeCanceledException()
    : ReservationBadRequestBaseException("کسب و کار اجازه ی کنسل کردن را نمی دهد");