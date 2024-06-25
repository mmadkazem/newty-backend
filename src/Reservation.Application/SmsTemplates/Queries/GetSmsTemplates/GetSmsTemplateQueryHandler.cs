namespace Reservation.Application.SmsTemplates.Queries.GetSmsTemplates;

public sealed class GetSmsTemplateQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetSmsTemplatesQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetSmsTemplatesQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.SmsTemplates.Gets(request.BusinessId, cancellationToken);

        if(!responses.Any())
        {
            throw new SmsTemplateNotFoundException();
        }

        return responses;
    }
}