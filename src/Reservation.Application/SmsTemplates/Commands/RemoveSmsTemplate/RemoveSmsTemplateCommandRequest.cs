namespace Reservation.Application.SmsTemplates.Commands.RemoveSmsTemplate;


public sealed record RemoveSmsTemplateCommandRequest(Guid Id, Guid BusinessId) : IRequest
{
    public static RemoveSmsTemplateCommandRequest Create(Guid id, Guid businessId)
        => new(id, businessId);
}
