namespace Reservation.Application.Account.Exceptions;


public class UserOrBusinessNotExistException : ReservationNotFoundBaseException
{
    public UserOrBusinessNotExistException()
        : base("همچنین کابری با همچنین اطلاعاتی وجود") { }
}