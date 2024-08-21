namespace Reservation.Application.Account.Exceptions;

public sealed class UserNotFoundException : NewtyNotFoundBaseException
{
    public UserNotFoundException()
        : base("کابری با این اطلاعات یافت نشد") { }
}