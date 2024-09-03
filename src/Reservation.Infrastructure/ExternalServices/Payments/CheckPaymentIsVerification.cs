namespace Reservation.Infrastructure.ExternalServices.Payments;



public sealed class CheckPaymentIsVerificationService : ICheckPaymentIsVerificationService
{
    private readonly Payment _payment;
    public CheckPaymentIsVerificationService()
    {
        _payment = new();
    }

    public async Task<CheckPaymentIsVerificationResponse> Verification(string authorizy, decimal amount)
    {
        Env.Load();
        var merchantId = Env.GetString("ZARINPAL_MERCHANTID");
        var result = await _payment.Verification(new()
        {
            Amount = (int)amount,
            Authority = authorizy,
            MerchantId = merchantId
        }, Payment.Mode.sandbox);

        return result.Status switch
        {
            101 => new(result.ExtraDetail, PaymentResult.Verified, result.RefId),
            -54 => new(result.ExtraDetail, PaymentResult.InvalidAuthority, result.RefId),
            -55 => new(result.ExtraDetail, PaymentResult.NotFound, result.RefId),
            -51 => new(result.ExtraDetail, PaymentResult.Fail, result.RefId),
            _ => new("خطا ی غیر منتظره رخ داده است", PaymentResult.Error, 0),
        };
    }
}