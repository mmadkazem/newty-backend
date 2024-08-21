namespace Reservation.Application.Posts.Exceptions;

public sealed class PostNotFoundException : NewtyNotFoundBaseException
{
    public PostNotFoundException()
        : base("پستی یافت نشد") { }
}