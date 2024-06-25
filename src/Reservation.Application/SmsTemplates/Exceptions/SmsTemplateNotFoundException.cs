namespace Reservation.Application.SmsTemplates.Exceptions;


public sealed class SmsTemplateNotFoundException()
    : ReservationNotFoundBaseException("تمپلیتی یافت نشد");