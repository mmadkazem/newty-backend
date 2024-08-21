namespace Reservation.Application.BusinessServices.Exceptions;


public sealed class ServiceNotFoundException : NewtyNotFoundBaseException
{
    public ServiceNotFoundException() : base("خدماتی یافت نشد") { }
}