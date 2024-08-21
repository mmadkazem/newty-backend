namespace Reservation.Application.Cities.Exceptions;

public sealed class CityNotFoundException : NewtyNotFoundBaseException
{
    public CityNotFoundException()
        : base("این شهر وجود ندارد") { }
}