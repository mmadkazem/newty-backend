namespace Reservation.Application.Wallets.Exceptions;

public class BalanceInsufficientException()
    : NewtyBadRequestBaseException("موجودی کافی نیست")
{ }