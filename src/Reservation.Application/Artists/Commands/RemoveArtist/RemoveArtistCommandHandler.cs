namespace Reservation.Application.Artists.Commands.RemoveArtist;

public sealed class RemoveArtistCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveArtistCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemoveArtistCommandRequest request, CancellationToken cancellationToken)
    {
        var artist = await _uow.Artists.FindAsync(request.Id, cancellationToken)
            ?? throw new ArtistNotFoundException();

        if (artist.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToRemoveItemException("آرتیست");
        }

        _uow.Artists.Remove(artist);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}