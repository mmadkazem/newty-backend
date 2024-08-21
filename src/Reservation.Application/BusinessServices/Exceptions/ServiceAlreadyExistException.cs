namespace Reservation.Application.BusinessServices.Exceptions;


public class ServiceAlreadyExistException : NewtyBadRequestBaseException
{
    public ServiceAlreadyExistException()
        : base("این سرویس از وجود دارد") { }
}