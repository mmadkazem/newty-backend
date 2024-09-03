namespace Reservation.Application.Artists.Commands.UpdateArtist;

public sealed class UpdateArtistCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateArtistCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateArtistCommandRequest request, CancellationToken cancellationToken)
    {
        var artist = await _uow.Artists.FindAsync(request.Id, cancellationToken)
            ?? throw new ArtistNotFoundException();

        artist.Business.IsValidate();

        if (artist.Name != request.Name && !await _uow.Artists.AnyAsync(request.Name, cancellationToken))
        {
            throw new ArtistNameAlreadyExistException();
        }

        if (artist.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToChangeItemException("آرتیست");
        }

        artist.Name = request.Name;
        artist.Description = request.Description;
        artist.CoverImagePath = request.CoverImagePath;
        artist.Active = request.Active;
        artist.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}