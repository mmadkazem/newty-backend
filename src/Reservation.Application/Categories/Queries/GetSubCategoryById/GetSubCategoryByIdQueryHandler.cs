
namespace Reservation.Application.Categories.Queries.GetSubCategoryById;


public sealed class GetSubCategoryByIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetSubCategoryByIdQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetSubCategoryByIdQueryRequest request, CancellationToken cancellationToken)
    {
        return await _uow.Categories.GetSubCategory(request.Id)
            ?? throw new CategoryNotFoundException();
    }
}