namespace Reservation.Application.SmsCredits.Exceptions;


public sealed class SmsCreditAlreadyExistException()
    : NewtyBadRequestBaseException("اعتبار پیامکی از قبل وجود دارد");