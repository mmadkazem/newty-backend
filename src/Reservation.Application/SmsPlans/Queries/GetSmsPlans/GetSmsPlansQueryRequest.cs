namespace Reservation.Application.SmsPlans.Queries.GetSmsPlans;


public sealed record GetSmsPlansQueryRequest(int Page) : IRequest<IEnumerable<IResponse>>;

public sealed record GetSmsPlansQueryResponse
(
    Guid Id, string Name,
    string Description,
    int Count, decimal Price,
    string CoverImagePath, int Discount
) : IResponse;

public sealed class GetSmsPlansQueryHandler(IUnitOfWork uow) : IRequestHandler<GetSmsPlansQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;
    async Task<IEnumerable<IResponse>> IRequestHandler<GetSmsPlansQueryRequest, IEnumerable<IResponse>>.Handle(GetSmsPlansQueryRequest request, CancellationToken cancellationToken)
    {
        var smsPlans = await _uow.SmsPlans.Get(request.Page, cancellationToken);
        if (!smsPlans.Any())
        {
            throw new SmsPlanNotFoundException();
        }

        return smsPlans;
    }
}