namespace Reservation.Application.Businesses.Queries.Search;
public sealed class SearchBusinessHandler(IUnitOfWork uow) : IRequestHandler<SearchBusinessQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(SearchBusinessQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Businesses.Search(request.Page, request.Size, request.Key, request.City, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}