namespace Reservation.Application.Wallets.Exceptions;

public sealed class WalletNotFoundException()
    : ReservationNotFoundBaseException("کیف پولی یافت نشد") { }