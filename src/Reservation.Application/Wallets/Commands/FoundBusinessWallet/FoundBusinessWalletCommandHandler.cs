namespace Reservation.Application.Wallets.Commands.FoundBusinessWallet;

public sealed class FoundBusinessWalletCommandHandler
        (IUnitOfWork uow,
        IPaymentProvider paymentProvider)
    : IRequestHandler<FoundBusinessWalletCommandRequest, string>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IPaymentProvider _paymentProvider = paymentProvider;

    public async Task<string> Handle(FoundBusinessWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var businessRequestPay = await _uow.BusinessRequestPays.FindAsync(request.RequestPayId, request.Authorizy, cancellationToken)
            ?? throw new BusinessRequestPayNotFoundException();

        var wallet = await _uow.Wallets.FindAsyncByBusinessId(businessRequestPay.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        var result = await _paymentProvider.Verification(request.Authorizy, businessRequestPay.Amount);
        if (result.Status == PaymentStatus.Error)
        {
            return VerifyBusinessChargeWalletCommandResponse.UnSuccessRedirectUrl;
        }


        businessRequestPay.Authorizy = request.Authorizy;
        businessRequestPay.RefId = businessRequestPay.RefId;
        businessRequestPay.PayDate = DateTime.Now;
        businessRequestPay.IsPay = true;

        wallet.Credit += businessRequestPay.Amount;
        wallet.ModifiedOn = DateTime.Now;
        wallet.Transactions.Add(new() { Amount = businessRequestPay.Amount, Type = TransactionType.Charge });

        await _uow.SaveChangeAsync(cancellationToken);
        return VerifyBusinessChargeWalletCommandResponse.SuccessRedirectUrl;
    }
}
