namespace Reservation.Application.SmsTemplates.Queries.GetSmsTemplate;


public record GetSmsTemplateQueryRequest(Guid Id) : IRequest<IResponse>;

public record GetSmsTemplateQueryResponse
(
    Guid Id,
    string Name,
    string Description,
    Guid BusinessId
) : IResponse;
