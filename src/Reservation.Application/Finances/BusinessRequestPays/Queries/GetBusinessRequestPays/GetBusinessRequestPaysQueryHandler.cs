namespace Reservation.Application.Finances.BusinessRequestPays.Queries.GetBusinessRequestPays;

public sealed class GetBusinessRequestPaysQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessRequestPaysQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetBusinessRequestPaysQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.BusinessRequestPays.GetByBusinessId(request.Page, request.Size, request.BusinessId, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}