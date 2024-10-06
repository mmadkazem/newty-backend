namespace Reservation.Infrastructure.ExternalServices.Payments;


public sealed class PaymentUrlGeneratorService(IOptions<PaymentUrlOption> option) : IPaymentUrlGeneratorService
{
    private readonly PaymentUrlOption _option = option.Value;
    public string GenerateChargeWalletRedirectUrl(Guid requestPayId, WalletType walletType)
    {
        StringBuilder url = new(_option.BaseUrl);
        url.Append(_option.ChargeWalletRedirectUrl);
        url.Replace(_option.WalletType, walletType.ToString());
        url.Replace(_option.ReplaceItem, requestPayId.ToString());
        return url.ToString();
    }

    public string GenerateReserveTimeRedirectUrl(Guid reserveTimeId)
    {
        StringBuilder url = new(_option.BaseUrl);
        url.Append(_option.ReserveTimeRedirectUrl);
        url.Replace(_option.ReplaceItem, reserveTimeId.ToString());
        return url.ToString();
    }
}