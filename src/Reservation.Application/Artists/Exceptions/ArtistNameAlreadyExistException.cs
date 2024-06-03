namespace Reservation.Application.Artists.Exceptions;

public class ArtistNameAlreadyExistException : ReservationBadRequestBaseException
{
    public ArtistNameAlreadyExistException()
        : base("این نام وجود دارد") { }
}