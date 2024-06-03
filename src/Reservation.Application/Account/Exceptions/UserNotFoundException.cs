namespace Reservation.Application.Account.Exceptions;

public sealed class UserNotFoundException : ReservationNotFoundBaseException
{
    public UserNotFoundException()
        : base("کابری با این اطلاعات یافت نشد") { }
}