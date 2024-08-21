namespace Reservation.Application.Wallets.Exceptions;

public sealed class WalletNotFoundException()
    : NewtyNotFoundBaseException("کیف پولی یافت نشد")
{ }