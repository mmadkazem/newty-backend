namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class ReserveTimeNotFoundException : ReservationNotFoundBaseException
{
    public ReserveTimeNotFoundException()
        : base("وقتی پیدا نشد") { }
}