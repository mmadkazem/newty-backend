namespace Reservation.Application.Categories.Queries.GetMainCategory;


public sealed class GetMainCategoryHandler(IUnitOfWork uow) : IRequestHandler<GetMainCategoryQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetMainCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _uow.Categories.GetMainCategory();
        if (!categories.Any())
        {
            throw new CategoryNotFoundException();
        }

        return categories;
    }
}