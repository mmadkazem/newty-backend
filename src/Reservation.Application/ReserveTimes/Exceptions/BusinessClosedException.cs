namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class BusinessClosedException()
  : NewtyBadRequestBaseException("کسب و کار فعلا قادر به ارایٔه خدمات نیست");