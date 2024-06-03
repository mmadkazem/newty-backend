namespace Reservation.Application.Account.Exceptions;

public class PhonNumberAlreadyExistException : ReservationBadRequestBaseException
{
    public PhonNumberAlreadyExistException()
        : base("این شماره تلفن وجود دارد") { }
}