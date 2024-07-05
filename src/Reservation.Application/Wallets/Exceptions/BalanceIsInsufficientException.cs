namespace Reservation.Application.Wallets.Exceptions;

public class BalanceInsufficientException()
    : ReservationBadRequestBaseException("موجودی کافی نیست") { }