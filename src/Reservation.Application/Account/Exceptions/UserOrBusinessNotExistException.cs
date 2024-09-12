namespace Reservation.Application.Account.Exceptions;


public class UserOrBusinessNotExistException : NewtyNotFoundBaseException
{
    public UserOrBusinessNotExistException()
        : base("همچنین کابری با همچنین اطلاعاتی وجود ندارد") { }
}