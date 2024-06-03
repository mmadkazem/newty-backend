namespace Reservation.Application.Account.Exceptions;


public class NotEqualActualAndExpectedException : ReservationBadRequestBaseException
{
    public NotEqualActualAndExpectedException()
        : base("کد اشتباه است کد را درست وارد کنید") { }
}