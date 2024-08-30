namespace Reservation.Application.BusinessServices.Queries.GetServicesByBusinessId;

public sealed class GetServicesByBusinessIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetServicesByBusinessIdQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetServicesByBusinessIdQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Services.GetServiceByBusinessId(request.Page, request.Size, request.BusinessId, cancellationToken);

        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}