
namespace Reservation.Application.Categories.Queries.GetCategory;


public sealed class GetCategoryQueryHandler(IUnitOfWork uow) : IRequestHandler<GetCategoryQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        return await _uow.Categories.GetCategory(request.Id, cancellationToken)
            ?? throw new CategoryNotFoundException();
    }
}