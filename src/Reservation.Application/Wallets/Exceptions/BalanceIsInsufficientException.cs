namespace Reservation.Application.Wallets.Exceptions;

public class BalanceInsufficientException()
    : ReservationBadRequestBaseException("The wallet balance is insufficient") { }