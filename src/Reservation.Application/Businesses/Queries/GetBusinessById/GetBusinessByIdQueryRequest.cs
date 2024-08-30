namespace Reservation.Application.Businesses.Queries.GetBusinessById;


public sealed record GetBusinessByIdQueryRequest(Guid BusinessId) : IRequest<IResponse>;

public sealed record GetBusinessByIdQueryResponse(Guid Id, string Name, string Address, string CoverImagePath) : IResponse;


public sealed class GetBusinessByIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessByIdQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetBusinessByIdQueryRequest request, CancellationToken cancellationToken)
        => await _uow.Businesses.GetBusinessById(request.BusinessId, cancellationToken)
                ?? throw new BusinessNotFoundException();
}