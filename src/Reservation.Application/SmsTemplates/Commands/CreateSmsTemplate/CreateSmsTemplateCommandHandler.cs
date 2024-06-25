namespace Reservation.Application.SmsTemplates.Commands.CreateSmsTemplate;

public class CreateSmsTemplateCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateSmsTemplateCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateSmsTemplateCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessesNotFoundException();

        SmsTemplate smsTemplate = new()
        {
            Name = request.Name,
            Description = request.Description,
            Business = business
        };

        _uow.SmsTemplates.Add(smsTemplate);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}