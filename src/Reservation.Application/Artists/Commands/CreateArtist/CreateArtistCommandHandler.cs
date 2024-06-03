namespace Reservation.Application.Artists.Commands.CreateArtist;

public sealed class CreateArtistCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateArtistCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateArtistCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessesNotFoundException();

        Artist artist = new()
        {
            Name = request.Name,
            CoverImagePath = request.CoverImagePath,
            Description = request.Description,
            Business = business
        };

        _uow.Businesses.AddArtist(artist);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}