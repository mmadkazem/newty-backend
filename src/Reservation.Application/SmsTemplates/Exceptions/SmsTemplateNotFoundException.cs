namespace Reservation.Application.SmsTemplates.Exceptions;


public sealed class SmsTemplateNotFoundException()
    : ReservationNotFoundBaseException("قالب پیامکی یافت نشد");