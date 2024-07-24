
namespace Reservation.Application.Categories.Queries.GetCategories;


public sealed class GetCategoriesQueryHandler(IUnitOfWork uow) : IRequestHandler<GetCategoriesQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _uow.Categories.GetCategories(cancellationToken);
        if (!categories.Any())
        {
            throw new CategoryNotFoundException();
        }

        return categories;
    }
}