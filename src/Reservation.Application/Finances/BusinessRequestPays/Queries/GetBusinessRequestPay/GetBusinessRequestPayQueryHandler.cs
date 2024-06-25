namespace Reservation.Application.Finances.BusinessRequestPays.Queries.GetBusinessRequestPay;

public sealed class GetBusinessRequestPayQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessRequestPayQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetBusinessRequestPayQueryRequest request, CancellationToken cancellationToken)
        => await _uow.BusinessRequestPays.Get(request.Id, cancellationToken)
            ?? throw new BusinessRequestPayNotFoundException();
}