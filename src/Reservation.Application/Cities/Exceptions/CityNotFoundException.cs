namespace Reservation.Application.Cities.Exceptions;

public sealed class CityNotFoundException : ReservationNotFoundBaseException
{
    public CityNotFoundException()
        : base("این شهر وجود ندارد") { }
}