namespace Reservation.Application.Artists.Exceptions;

public class ArtistNotFoundException : NewtyNotFoundBaseException
{
    public ArtistNotFoundException()
        : base("آرتیستی با این اطلاعات یافت نشد") { }
}