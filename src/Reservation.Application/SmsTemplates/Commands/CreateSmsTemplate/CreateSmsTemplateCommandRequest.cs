namespace Reservation.Application.SmsTemplates.Commands.CreateSmsTemplate;


public record CreateSmsTemplateCommandRequest
(
    Guid BusinessId,
    string Name,
    string Description
) : IRequest
{
    public static CreateSmsTemplateCommandRequest Create(Guid businessId, CreateSmsTemplateDTO model)
        => new(businessId, model.Name, model.Description);
}

public record CreateSmsTemplateDTO(string Name, string Description);
