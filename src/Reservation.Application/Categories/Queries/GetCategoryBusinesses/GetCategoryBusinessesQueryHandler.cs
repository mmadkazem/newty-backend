namespace Reservation.Application.Categories.Queries.GetCategoryBusinesses;

public sealed class GetCategoryBusinessesQueryHandler(IUnitOfWork uow) : IRequestHandler<GetCategoryBusinessesQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetCategoryBusinessesQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Categories.GetBusiness(request.CategoryId, request.Page, cancellationToken);
        if (!responses.Any())
        {
            throw new BusinessNotFoundException();
        }
        return responses;
    }
}