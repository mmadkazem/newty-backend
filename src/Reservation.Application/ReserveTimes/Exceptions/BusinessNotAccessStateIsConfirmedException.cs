namespace Reservation.Application.ReserveTimes.Exceptions;

public class BusinessNotAccessStateIsConfirmedException()
    : ReservationBadRequestBaseException("شما نمی توانید تایید کنید");