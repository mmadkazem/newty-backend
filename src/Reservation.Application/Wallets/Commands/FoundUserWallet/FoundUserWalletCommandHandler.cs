namespace Reservation.Application.Wallets.Commands.FoundUserWallet;


public sealed class FoundUserWalletCommandHandler(IUnitOfWork uow, IPaymentProvider paymentProvider)
    : IRequestHandler<FoundUserWalletCommandRequest, string>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IPaymentProvider _paymentProvider = paymentProvider;

    public async Task<string> Handle(FoundUserWalletCommandRequest request, CancellationToken cancellationToken)
    {
        var userRequestPay = await _uow.UserRequestPays.FindAsync(request.RequestPayId, request.Authorizy, cancellationToken)
            ?? throw new UserRequestPayNotFoundException();

        var result = await _paymentProvider.Verification(request.Authorizy, userRequestPay.Amount);
        if (!(result.Status == PaymentStatus.Verified))
        {
            return VerifyUserChargeWalletCommandResponse.UnSuccessRedirectUrl;
        }

        var wallet = await _uow.Wallets.FindAsyncByUserId(userRequestPay.UserId, cancellationToken)
            ?? throw new WalletNotFoundException();

        userRequestPay.Authority = request.Authorizy;
        userRequestPay.RefId = result.RefId;
        userRequestPay.PayDate = DateTime.Now;
        userRequestPay.IsPay = true;

        wallet.Credit += userRequestPay.Amount;
        wallet.ModifiedOn = DateTime.Now;
        wallet.Transactions.Add(new() { Amount = userRequestPay.Amount, Type = TransactionType.Charge });

        await _uow.SaveChangeAsync(cancellationToken);

        return VerifyUserChargeWalletCommandResponse.SuccessRedirectUrl;
    }
}