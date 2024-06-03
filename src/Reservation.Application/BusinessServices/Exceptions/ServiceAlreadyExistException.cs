namespace Reservation.Application.BusinessServices.Exceptions;


public class ServiceAlreadyExistException : ReservationBadRequestBaseException
{
    public ServiceAlreadyExistException()
        : base("این سرویس از وجود دارد") { }
}