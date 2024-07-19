namespace Reservation.Application.SmsPlans.Exceptions;


public sealed class SmsPlanNotFoundException()
    : ReservationNotFoundBaseException("طرح پیامکی یافت نشد");