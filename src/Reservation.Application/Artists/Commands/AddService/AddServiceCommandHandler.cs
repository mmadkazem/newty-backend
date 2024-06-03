namespace Reservation.Application.Artists.Commands.AddService;

public sealed class AddServiceCommandHandler(IUnitOfWork uow) : IRequestHandler<AddServiceCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(AddServiceCommandRequest request, CancellationToken cancellationToken)
    {
        var service = await _uow.Businesses.FindAsyncService(request.ServiceId, cancellationToken)
            ?? throw new ServiceNotFoundException();

        Artist artist = await _uow.Businesses.FindAsyncArtist(request.ArtistId, cancellationToken)
            ?? throw new ArtistNotFoundException();

        artist.Services.Add(service);
        await _uow.SaveChangeAsync(cancellationToken);

    }
}