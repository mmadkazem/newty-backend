namespace Reservation.Application.SmsPlans.Queries.GetSmsPlans;


public sealed record GetSmsPlansQueryRequest(int Page, int Size) : IRequest<Response>;

public sealed record GetSmsPlansQueryResponse
(
    Guid Id, string Name,
    string Description,
    int Count, decimal Price,
    string CoverImagePath, int Discount
) : IResponse;

public sealed class GetSmsPlansQueryHandler(IUnitOfWork uow) : IRequestHandler<GetSmsPlansQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;
    public async Task<Response> Handle(GetSmsPlansQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.SmsPlans.Get(request.Page, request.Size, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}