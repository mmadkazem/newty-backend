namespace Reservation.Application.Wallets.Exceptions;


public sealed class PaymentInvalidException
    : NewtyBadRequestBaseException
{
    public const string ErrorMessage = "مشکلی به وجود آمده است لطفا دوباره امتحان کنید";

    public PaymentInvalidException() : base(ErrorMessage) { }
    public PaymentInvalidException(string message) : base(message) { }
}