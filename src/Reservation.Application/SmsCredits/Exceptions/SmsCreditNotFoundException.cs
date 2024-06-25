namespace Reservation.Application.SmsCredits.Exceptions;


public sealed class SmsCreditNotFoundException()
    : ReservationNotFoundBaseException("حساب پیامکی وجود ندارد") { }