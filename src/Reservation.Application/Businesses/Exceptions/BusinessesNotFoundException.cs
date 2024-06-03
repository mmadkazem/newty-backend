namespace Reservation.Application.Businesses.Exceptions;


public class BusinessesNotFoundException : ReservationNotFoundBaseException
{
    public BusinessesNotFoundException() : base("کسب و کاری یافت نشد") { }

}