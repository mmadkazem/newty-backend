namespace Reservation.Application.SmsCredits.Commands.CreateSmsCredit;

public sealed class CreateSmsCreditCommandHandler(IUnitOfWork uow)
    : IRequestHandler<CreateSmsCreditCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateSmsCreditCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessesNotFoundException();

        SmsCredit smsCredit = new()
        {
            SmsCount = request.Count,
            Business = business
        };
        _uow.SmsCredits.Add(smsCredit);

        await _uow.SaveChangeAsync(cancellationToken);
    }
}