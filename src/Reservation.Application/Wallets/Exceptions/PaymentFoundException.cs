namespace Reservation.Application.Wallets.Exceptions;


public sealed class PaymentFoundException(string message)
    : ReservationBadRequestBaseException(message);