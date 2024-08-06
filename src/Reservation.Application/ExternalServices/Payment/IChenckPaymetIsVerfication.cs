namespace Reservation.Application.ExternalServices.Payment;

public interface ICheckPaymentIsVerificationService
{
    Task<CheckPaymentIsVerificationResponse> Verification(string authorizy, decimal amount);
}
public readonly record struct CheckPaymentIsVerificationResponse(string ExtraDetail, PaymentResult Result, int RefId);
public enum PaymentResult
{
    Verified,
    NotFound,
    Fail,
    InvalidAuthority,
    Error
}