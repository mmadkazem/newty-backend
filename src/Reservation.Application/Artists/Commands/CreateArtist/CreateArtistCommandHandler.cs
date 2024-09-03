namespace Reservation.Application.Artists.Commands.CreateArtist;

public sealed class CreateArtistCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateArtistCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateArtistCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        business.IsValidate();

        List<BusinessService> services = [];
        foreach (var serviceId in request.Services)
        {
            var service = await _uow.Services.FindAsync(serviceId, cancellationToken)
            ?? throw new ServiceNotFoundException();

            services.Add(service);
        }

        Artist artist = new()
        {
            Name = request.Name,
            CoverImagePath = request.CoverImagePath,
            Description = request.Description,
            Business = business,
            Services = services
        };

        _uow.Artists.Add(artist);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}