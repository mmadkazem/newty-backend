namespace Reservation.Application.Businesses.Exceptions;


public class BusinessNotFoundException : ReservationNotFoundBaseException
{
    public BusinessNotFoundException() : base("کسب و کاری یافت نشد") { }

}