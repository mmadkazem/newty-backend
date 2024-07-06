namespace Reservation.Application.Categories.Queries.GetSubCategoryByCategoryId;

public sealed class GetSubCategoriesByCategoryIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetSubCategoriesByCategoryIdQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetSubCategoriesByCategoryIdQueryRequest request, CancellationToken cancellationToken)
    {
        return await _uow.Categories.GetSubCategoryByCategoryId(request.Id, cancellationToken)
            ?? throw new CategoryNotFoundException();
    }
}