namespace Reservation.Application.Categories.Queries.SearchCategory;

public sealed class SearchCategoryQueryHandler(IUnitOfWork uow) : IRequestHandler<SearchCategoryQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(SearchCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Categories.Search(request.Key, cancellationToken);

        if (!responses.Any())
        {
            throw new CategoryNotFoundException();
        }

        return responses;
    }
}