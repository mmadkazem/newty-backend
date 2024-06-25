namespace Reservation.Application.Posts.Exceptions;

public sealed class PostNotFoundException : ReservationNotFoundBaseException
{
    public PostNotFoundException()
        : base("پستی یافت نشد") { }
}