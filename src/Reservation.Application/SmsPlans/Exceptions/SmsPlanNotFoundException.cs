namespace Reservation.Application.SmsPlans.Exceptions;


public sealed class SmsPlanNotFoundException()
    : NewtyNotFoundBaseException("طرح پیامکی یافت نشد");