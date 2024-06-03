namespace Reservation.Application.Categories.Exceptions;


public class TitleAlreadyExistException : ReservationBadRequestBaseException
{
    public TitleAlreadyExistException()
        : base("این عنوان وجود دارد") { }
}