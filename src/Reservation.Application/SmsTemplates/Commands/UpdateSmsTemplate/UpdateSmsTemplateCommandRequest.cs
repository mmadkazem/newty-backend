namespace Reservation.Application.SmsTemplates.Commands.UpdateSmsTemplate;


public record UpdateSmsTemplateCommandRequest
(
    Guid Id,
    Guid BusinessId,
    string Name,
    string Description
) : IRequest
{
    public static UpdateSmsTemplateCommandRequest Create(Guid id, Guid businessId, UpdateSmsTemplateDTO model)
        => new(id, businessId, model.Name, model.Description);
}

public record UpdateSmsTemplateDTO(string Name, string Description);
