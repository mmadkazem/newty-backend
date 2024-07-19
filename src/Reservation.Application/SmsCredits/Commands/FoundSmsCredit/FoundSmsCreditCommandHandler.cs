namespace Reservation.Application.SmsCredits.Commands.FoundSmsCredit;

public sealed class FoundSmsCreditCommandHandler(IUnitOfWork uow) : IRequestHandler<FoundSmsCreditCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(FoundSmsCreditCommandRequest request, CancellationToken cancellationToken)
    {
        var wallet = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        var smsCredit = await _uow.SmsCredits.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new SmsCreditNotFoundException();

        var plan = await _uow.SmsPlans.FindAsync(request.SMSPlanId, cancellationToken)
            ?? throw new SmsPlanNotFoundException();

        if (wallet.Credit - plan.Price < 0)
        {
            throw new BalanceInsufficientException();
        }
        wallet.Credit -= plan.Price;
        smsCredit.SmsCount += plan.SmsCount;
        smsCredit.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}
