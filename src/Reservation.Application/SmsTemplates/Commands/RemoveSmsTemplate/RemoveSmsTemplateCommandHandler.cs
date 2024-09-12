namespace Reservation.Application.SmsTemplates.Commands.RemoveSmsTemplate;

public sealed class RemoveSmsTemplateCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveSmsTemplateCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemoveSmsTemplateCommandRequest request, CancellationToken cancellationToken)
    {
        var smsTemplate = await _uow.SmsTemplates.FindAsync(request.Id, cancellationToken)
            ?? throw new SmsTemplateNotFoundException();

        if (smsTemplate.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToChangeItemException("تمپلیت پیامک");
        }

        _uow.SmsTemplates.Remove(smsTemplate);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}