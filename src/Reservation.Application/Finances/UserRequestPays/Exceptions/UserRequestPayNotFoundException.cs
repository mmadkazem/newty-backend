namespace Reservation.Application.Finances.UserRequestPays.Exceptions;


public class UserRequestPayNotFoundException()
    : ReservationNotFoundBaseException("همچنین درخواست پرداختی وجود ندارد");