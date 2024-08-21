namespace Reservation.Application.ReserveTimes.Exceptions;

public sealed class ThisTimeIsNotInTheWorkingTimeException()
    : NewtyBadRequestBaseException("این زمان در بازه ی زمانی کاری کسب و کار نیست");