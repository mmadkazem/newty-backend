namespace Reservation.Application.SmsCredits.Exceptions;


public sealed class SmsCreditAlreadyExistException()
    : ReservationBadRequestBaseException("اعتبار پیامکی از قبل وجود دارد");