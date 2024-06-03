namespace Reservation.Application.Categories.Queries.GetSubCategory;

public sealed class GetSubCategoriesQueryHandler(IUnitOfWork uow) : IRequestHandler<GetSubCategoriesQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetSubCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var subCategories = await _uow.Categories.GetSubCategories(request.Page, cancellationToken);
        if (!subCategories.Any())
        {
            throw new CategoryNotFoundException();
        }

        return subCategories;
    }
}