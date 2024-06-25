namespace Reservation.Application.Finances.BusinessRequestPays.Exceptions;


public class BusinessRequestPayNotFoundException()
    : ReservationBadRequestBaseException("همچنین درخواست پرداختی وجود ندارد") { }