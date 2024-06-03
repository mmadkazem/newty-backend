namespace Reservation.Application.Cities.Exceptions;



public class CityAlreadyExistException : ReservationBadRequestBaseException
{
    public CityAlreadyExistException()
        : base("این شهر وجود دارد") { }
}