namespace Reservation.Infrastructure.ExternalServices.Payments;



public sealed class PaymentProvider(IZarinpalService zarinpalService) : IPaymentProvider
{
    private readonly IZarinpalService _zarinpalService = zarinpalService;

    public async Task<PaymentResult> RequestPaymentAsync(int amount, string description, string callBackUrl)
    {
        var result = await _zarinpalService.RequestAsync(new (amount, description, callBackUrl));
        if (!result.IsSuccessStatusCode && result.Data is null)
        {
            return null;
        }
        return new (result.Data.Authority, result.RedirectUrl);
    }

    public async Task<CheckPaymentIsVerificationResponse> Verification(string authorizy, int amount)
    {
        var result = await _zarinpalService.VerifyAsync(new (amount, authorizy));
        if (!result.IsSuccessStatusCode)
        {
            return new("پرداخت با شکست مواجه شد.", PaymentStatus.Error, 0);
        }
        return new("پرداخت با موفقیت انجام شد.", PaymentStatus.Verified, ulong.Parse(result.RefId.ToString()));

    }
}