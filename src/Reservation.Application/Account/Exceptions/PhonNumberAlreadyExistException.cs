namespace Reservation.Application.Account.Exceptions;

public class PhonNumberAlreadyExistException : NewtyBadRequestBaseException
{
    public PhonNumberAlreadyExistException()
        : base("این شماره تلفن وجود دارد") { }
}