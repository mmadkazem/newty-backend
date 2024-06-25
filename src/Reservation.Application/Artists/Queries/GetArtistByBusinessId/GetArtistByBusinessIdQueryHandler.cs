namespace Reservation.Application.Artists.Queries.GetArtistByBusinessId;

public sealed class GetArtistByBusinessIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetArtistByBusinessIdQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetArtistByBusinessIdQueryRequest request, CancellationToken cancellationToken)
    {
        var artists = await _uow.Artists.GetArtistByBusinessId(request.BusinessId, cancellationToken);
        if (!artists.Any())
        {
            throw new ArtistNotFoundException();
        }

        return artists;
    }
}