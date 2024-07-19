namespace Reservation.Application.ReserveTimes.Exceptions;

public sealed class ThisTimeIsNotInTheWorkingTimeException()
    : ReservationBadRequestBaseException("این زمان در بازه ی زمانی کاری کسب و کار نیست");