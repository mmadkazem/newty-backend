namespace Reservation.Application.Categories.Queries.GetCategoryBusinesses;

public sealed class GetCategoryBusinessesQueryHandler(IUnitOfWork uow) : IRequestHandler<GetCategoryBusinessesQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetCategoryBusinessesQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Categories.GetBusiness(request.CategoryId, request.Page, request.Size, request.City, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}