namespace Reservation.Share.Abstract.Exceptions;


public abstract class ReservationNotFoundBaseException : Exception
{
    protected ReservationNotFoundBaseException(string message) : base(message) {}
}