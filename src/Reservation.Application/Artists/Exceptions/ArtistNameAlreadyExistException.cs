namespace Reservation.Application.Artists.Exceptions;

public class ArtistNameAlreadyExistException : NewtyBadRequestBaseException
{
    public ArtistNameAlreadyExistException()
        : base("این نام وجود دارد") { }
}