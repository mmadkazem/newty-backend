namespace Reservation.Application.ExternalServices.PaymentProvider;


public interface IPaymentProvider
{
    Task<PaymentResult?> RequestPaymentAsync(int amount, string description, string callBackUrl);
    Task<CheckPaymentIsVerificationResponse> Verification(string authorizy, int amount);
}

public record PaymentResult(string Authority, string PaymentUrl);

public readonly record struct CheckPaymentIsVerificationResponse(string ExtraDetail, PaymentStatus Status, ulong RefId);
public enum PaymentStatus
{
    Verified,
    Error
}