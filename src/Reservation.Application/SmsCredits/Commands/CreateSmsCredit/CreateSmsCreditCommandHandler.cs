namespace Reservation.Application.SmsCredits.Commands.CreateSmsCredit;

public sealed class CreateSmsCreditCommandHandler(IUnitOfWork uow)
    : IRequestHandler<CreateSmsCreditCommandRequest, string>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<string> Handle(CreateSmsCreditCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsyncIncludeSMSCredit(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        if (business.SmsCredit is not null)
        {
            throw new SmsCreditAlreadyExistException();
        }

        SmsCredit smsCredit = new()
        {
            Business = business
        };
        _uow.SmsCredits.Add(smsCredit);

        await _uow.SaveChangeAsync(cancellationToken);

        return "اعتبار پیامکی ساخته شد";
    }
}