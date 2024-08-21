namespace Reservation.Application.Cities.Exceptions;



public class CityAlreadyExistException : NewtyBadRequestBaseException
{
    public CityAlreadyExistException()
        : base("این شهر وجود دارد") { }
}