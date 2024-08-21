namespace Reservation.Application.Account.Exceptions;


public class NotEqualActualAndExpectedException : NewtyBadRequestBaseException
{
    public NotEqualActualAndExpectedException()
        : base("کد اشتباه است کد را درست وارد کنید") { }
}