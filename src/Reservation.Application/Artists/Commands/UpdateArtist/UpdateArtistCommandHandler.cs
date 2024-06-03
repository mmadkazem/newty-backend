
namespace Reservation.Application.Artists.Commands.UpdateArtist;

public sealed class UpdateArtistCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateArtistCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateArtistCommandRequest request, CancellationToken cancellationToken)
    {
        var artist = await _uow.Businesses.FindAsyncArtist(request.Id, cancellationToken)
            ?? throw new ArtistNotFoundException();
        if (artist.Name != request.Name && !await _uow.Businesses.AnyAsyncArtist(request.Name, cancellationToken))
        {
            throw new ArtistNameAlreadyExistException();
        }
        artist.Name = request.Name;
        artist.Description = request.Description;
        artist.CoverImagePath = request.CoverImagePath;
        artist.Active = request.Active;
        artist.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}