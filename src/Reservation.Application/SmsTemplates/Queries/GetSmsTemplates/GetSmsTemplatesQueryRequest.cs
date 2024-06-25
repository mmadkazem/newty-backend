namespace Reservation.Application.SmsTemplates.Queries.GetSmsTemplates;


public record GetSmsTemplatesQueryRequest(Guid BusinessId) : IRequest<IEnumerable<IResponse>>;


public record GetSmsTemplatesQueryResponse(Guid Id, string Name) : IResponse;
