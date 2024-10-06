namespace Reservation.Application.Artists.Queries.GetArtistServices;

public sealed class GetArtistServicesQueryHandler(IUnitOfWork uow) : IRequestHandler<GetArtistServicesQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetArtistServicesQueryRequest request, CancellationToken cancellationToken)
    {
        var services = await _uow.Services.GetArtistServices(request.ArtistId, cancellationToken);
        if (!services.Any())
        {
            throw new ServiceNotFoundException();
        }

        return services;
    }
}