namespace Reservation.Application.BusinessServices.Queries.GetServicesByBusinessId;

public sealed class GetServicesByBusinessIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetServicesByBusinessIdQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetServicesByBusinessIdQueryRequest request, CancellationToken cancellationToken)
    {
        var services = await _uow.Businesses.GetServiceByBusinessId(request.BusinessId, cancellationToken);

        if (!services.Any())
        {
            throw new ServiceNotFoundException();
        }

        return services;
    }
}