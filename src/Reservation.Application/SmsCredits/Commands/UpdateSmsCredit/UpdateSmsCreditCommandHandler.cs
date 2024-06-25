namespace Reservation.Application.SmsCredits.Commands.UpdateSmsCredit;

public sealed class UpdateSmsCreditCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateSmsCreditCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateSmsCreditCommandRequest request, CancellationToken cancellationToken)
    {
        var smsCredit = await _uow.SmsCredits.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new SmsCreditNotFoundException();

        smsCredit.SmsCount = request.Count;
        smsCredit.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}
