namespace Reservation.Application.Businesses.Queries.Search;
public sealed class SearchBusinessHandler(IUnitOfWork uow) : IRequestHandler<SearchBusinessQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(SearchBusinessQueryRequest request, CancellationToken cancellationToken)
    {
        var businesses = await _uow.Businesses.Search(request.Page, request.Key, request.City, cancellationToken);
        if (!businesses.Any())
        {
            throw new BusinessNotFoundException();
        }

        return businesses;
    }
}