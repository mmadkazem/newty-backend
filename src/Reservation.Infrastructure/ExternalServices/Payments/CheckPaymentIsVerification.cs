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

        switch (result.Status)
        {
            case 101:
                return new(result.ExtraDetail, PaymentResult.Verified, result.RefId);
            case -54:
                return new(result.ExtraDetail, PaymentResult.InvalidAuthority, result.RefId);
            case -55:
                return new(result.ExtraDetail, PaymentResult.NotFound, result.RefId);
            case -51:
                return new(result.ExtraDetail, PaymentResult.Fail, result.RefId);
            default:
                return new("خطا ی غیر منتظره رخ داده است", PaymentResult.Error, 0);
        }
    }
}