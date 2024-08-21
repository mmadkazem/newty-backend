namespace Reservation.Application.ReserveTimes.Exceptions;

public class BusinessNotAccessStateIsConfirmedException()
    : NewtyBadRequestBaseException("شما نمی توانید تایید کنید");