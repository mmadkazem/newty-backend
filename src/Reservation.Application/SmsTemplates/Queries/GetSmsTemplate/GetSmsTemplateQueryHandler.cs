namespace Reservation.Application.SmsTemplates.Queries.GetSmsTemplate;

public sealed class GetSmsTemplateQueryHandler(IUnitOfWork uow) : IRequestHandler<GetSmsTemplateQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetSmsTemplateQueryRequest request, CancellationToken cancellationToken)
        => await _uow.SmsTemplates.Get(request.Id, cancellationToken)
            ?? throw new SmsTemplateNotFoundException();
}