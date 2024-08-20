namespace Reservation.Application.Wallets.Commands.FoundBusinessWallet;

public sealed class FoundBusinessWalletCommandHandler
        (IUnitOfWork uow,
        ICheckPaymentIsVerificationService checkVerification)
    : IRequestHandler<FoundBusinessWalletCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICheckPaymentIsVerificationService _checkPaymentIsVerificationService = checkVerification;

    public async Task Handle(FoundBusinessWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var businessRequestPay = await _uow.BusinessRequestPays.FindAsync(request.RequestPayId, cancellationToken)
            ?? throw new BusinessRequestPayNotFoundException();

        var result = await _checkPaymentIsVerificationService.Verification(request.Authorizy, businessRequestPay.Amount);
        if (!(result.Result == PaymentResult.Verified))
        {
            throw new PaymentFoundException(result.ExtraDetail);
        }

        var wallet = await _uow.Wallets.FindAsyncByBusinessId(businessRequestPay.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        businessRequestPay.Authorizy = request.Authorizy;
        businessRequestPay.RefId = businessRequestPay.RefId;
        businessRequestPay.PayDate = DateTime.Now;
        businessRequestPay.IsPay = true;

        wallet.Credit += businessRequestPay.Amount;
        wallet.ModifiedOn = DateTime.Now;
        wallet.Transactions.Add(new() { Amount = businessRequestPay.Amount, Type = TransactionType.Charge });

        await _uow.SaveChangeAsync(cancellationToken);
    }
}