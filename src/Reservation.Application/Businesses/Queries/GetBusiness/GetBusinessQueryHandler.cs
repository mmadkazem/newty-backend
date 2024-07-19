namespace Reservation.Application.Businesses.Queries.GetBusiness;

public sealed class GetBusinessQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetBusinessQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetBusinessQueryRequest request, CancellationToken cancellationToken)
        => await _uow.Businesses.Get(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();
}