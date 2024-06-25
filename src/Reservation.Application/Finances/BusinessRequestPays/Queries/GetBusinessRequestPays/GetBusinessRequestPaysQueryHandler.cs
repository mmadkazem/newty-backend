namespace Reservation.Application.Finances.BusinessRequestPays.Queries.GetBusinessRequestPays;

public sealed class GetBusinessRequestPaysQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessRequestPaysQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetBusinessRequestPaysQueryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<IResponse> responses = await _uow.BusinessRequestPays.GetByBusinessId(request.Page, request.BusinessId, cancellationToken);
        if (!responses.Any())
        {
            throw new BusinessRequestPayNotFoundException();
        }
        return responses;
    }
}