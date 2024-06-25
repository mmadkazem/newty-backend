namespace Reservation.Application.SmsTemplates.Commands.UpdateSmsTemplate;


public record UpdateSmsTemplateCommandRequest
(
    Guid Id,
    string Name,
    string Description
) : IRequest
{
    public static UpdateSmsTemplateCommandRequest Create(Guid businessId, UpdateSmsTemplateDTO model)
        => new(businessId, model.Name, model.Description);
}

public record UpdateSmsTemplateDTO(string Name, string Description);
