namespace Reservation.Application.Categories.Queries.GetTop3Category;


public sealed class GetTop3SubCategoryHandler(IUnitOfWork uow) : IRequestHandler<GetTop3SubCategoryQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetTop3SubCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _uow.Categories.Top3();
        if (!categories.Any())
        {
            throw new CategoryNotFoundException();
        }

        return categories;
    }
}