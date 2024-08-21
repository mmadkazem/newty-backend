namespace Reservation.Application.SmsTemplates.Exceptions;


public sealed class SmsTemplateNotFoundException()
    : NewtyNotFoundBaseException("قالب پیامکی یافت نشد");