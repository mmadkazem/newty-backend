namespace Reservation.Application.SmsCredits.Exceptions;


public sealed class SmsCreditNotFoundException()
    : NewtyNotFoundBaseException("حساب پیامکی وجود ندارد")
{ }