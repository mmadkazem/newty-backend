namespace Reservation.Application.SmsTemplates.Commands.UpdateSmsTemplate;

public sealed class UpdateSmsTemplateCommandHandler(IUnitOfWork uow)
    : IRequestHandler<UpdateSmsTemplateCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateSmsTemplateCommandRequest request, CancellationToken cancellationToken)
    {
        SmsTemplate smsTemplate = await _uow.SmsTemplates.FindAsync(request.Id, cancellationToken)
            ?? throw new SmsTemplateNotFoundException();

        smsTemplate.Name = request.Name;
        smsTemplate.Description = request.Description;
        smsTemplate.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}
