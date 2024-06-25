namespace Reservation.Application.Artists.Queries.GetArtist;

public sealed class GetArtistQueryHandler(IUnitOfWork uow) : IRequestHandler<GetArtistQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetArtistQueryRequest request, CancellationToken cancellationToken)
    {
        var artist = await _uow.Artists.Get(request.ArtistId, cancellationToken)
            ?? throw new ArtistNotFoundException();

        return artist;
    }
}