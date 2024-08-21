namespace Reservation.Application.ReserveTimes.Exceptions;

public class BusinessCannotBeCanceledException()
    : NewtyBadRequestBaseException("کسب و کار اجازه ی کنسل کردن را نمی دهد");