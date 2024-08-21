namespace Reservation.Application.Businesses.Exceptions;


public class BusinessNotFoundException : NewtyNotFoundBaseException
{
    public BusinessNotFoundException() : base("کسب و کاری یافت نشد") { }

}