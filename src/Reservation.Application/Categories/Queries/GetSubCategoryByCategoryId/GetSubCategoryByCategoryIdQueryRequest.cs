namespace Reservation.Application.Categories.Queries.GetSubCategoryByCategoryId;

public record GetSubCategoriesByCategoryIdQueryRequest(Guid Id) : IRequest<IEnumerable<IResponse>>
{
    public static implicit operator GetSubCategoriesByCategoryIdQueryRequest(Guid id)
        => new(id);
    public static implicit operator Guid(GetSubCategoriesByCategoryIdQueryRequest request)
        => request.Id;
}

