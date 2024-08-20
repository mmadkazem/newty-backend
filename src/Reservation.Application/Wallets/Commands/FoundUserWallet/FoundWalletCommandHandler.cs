namespace Reservation.Application.Wallets.Commands.FoundUserWallet;

public sealed class FoundUserWalletCommandHandler
        (IUnitOfWork uow,
        ICheckPaymentIsVerificationService checkPaymentIsVerificationService)
    : IRequestHandler<FoundUserWalletCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICheckPaymentIsVerificationService _checkPaymentIsVerificationService = checkPaymentIsVerificationService;

    public async Task Handle(FoundUserWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var userRequestPay = await _uow.UserRequestPays.FindAsync(request.RequestPayId, cancellationToken)
            ?? throw new UserRequestPayNotFoundException();


        var result = await _checkPaymentIsVerificationService.Verification(request.Authorizy, userRequestPay.Amount);
        if (!(result.Result == PaymentResult.Verified))
        {
            throw new PaymentFoundException(result.ExtraDetail);
        }

        var wallet = await _uow.Wallets.FindAsyncByUserId(userRequestPay.UserId, cancellationToken)
            ?? throw new WalletNotFoundException();

        userRequestPay.Authorizy = request.Authorizy;
        userRequestPay.RefId = result.RefId;
        userRequestPay.PayDate = DateTime.Now;
        userRequestPay.IsPay = true;

        wallet.Credit += userRequestPay.Amount;
        wallet.ModifiedOn = DateTime.Now;
        wallet.Transactions.Add(new() { Amount = userRequestPay.Amount, Type = TransactionType.Charge });

        await _uow.SaveChangeAsync(cancellationToken);
    }
}