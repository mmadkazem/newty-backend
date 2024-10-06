namespace Reservation.Application.ExternalServices.PaymentProvider;


public interface IPaymentUrlGeneratorService
{
    string GenerateChargeWalletRedirectUrl(Guid requestPayId, WalletType walletType);
    string GenerateReserveTimeRedirectUrl(Guid reserveTimeId);
}

public enum WalletType : byte
{
    Business,
    User
}