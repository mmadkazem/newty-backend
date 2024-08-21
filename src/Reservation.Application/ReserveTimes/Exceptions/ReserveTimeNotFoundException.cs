namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class ReserveTimeNotFoundException : NewtyNotFoundBaseException
{
    public ReserveTimeNotFoundException()
        : base("وقتی پیدا نشد") { }
}