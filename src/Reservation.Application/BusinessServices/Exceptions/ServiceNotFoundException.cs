namespace Reservation.Application.BusinessServices.Exceptions;


public sealed class ServiceNotFoundException : ReservationNotFoundBaseException
{
    public ServiceNotFoundException() : base("خدماتی یافت نشد") { }
}