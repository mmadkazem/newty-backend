namespace Reservation.Infrastructure.ExternalServices.Payments.Options;


public sealed class PaymentUrlOption
{
    public string BaseUrl { get; set; }
    public string ChargeWalletRedirectUrl { get; set; }
    public string ReserveTimeRedirectUrl { get; set; }
    public string ReplaceItem { get; set; }
    public string WalletType { get; set; }
}