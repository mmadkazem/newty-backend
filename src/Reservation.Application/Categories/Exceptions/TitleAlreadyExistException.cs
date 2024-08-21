namespace Reservation.Application.Categories.Exceptions;


public class TitleAlreadyExistException : NewtyBadRequestBaseException
{
    public TitleAlreadyExistException()
        : base("این عنوان وجود دارد") { }
}