namespace Reservation.Share.Abstract.Exceptions;


public abstract class ReservationBadRequestBaseException : Exception
{
    protected ReservationBadRequestBaseException(string message) : base(message) {}
}