namespace Reservation.Application.Artists.Exceptions;

public class ArtistNotFoundException : ReservationNotFoundBaseException
{
    public ArtistNotFoundException()
        : base("آرتیستی با این اطلاعات یافت نشد") { }
}