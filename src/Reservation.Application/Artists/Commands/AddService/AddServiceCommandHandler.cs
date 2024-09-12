namespace Reservation.Application.Artists.Commands.AddService;

public sealed class AddServiceCommandHandler(IUnitOfWork uow) : IRequestHandler<AddServiceCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(AddServiceCommandRequest request, CancellationToken cancellationToken)
    {
        var service = await _uow.Services.FindAsync(request.ServiceId, cancellationToken)
            ?? throw new ServiceNotFoundException();

        var artist = await _uow.Artists.FindAsync(request.ArtistId, cancellationToken)
            ?? throw new ArtistNotFoundException();

        if (service.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToChangeItemException("خدمات");
        }

        if (artist.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToChangeItemException("آرتیست");
        }

        artist.Services.Add(service);
        await _uow.SaveChangeAsync(cancellationToken);

    }
}