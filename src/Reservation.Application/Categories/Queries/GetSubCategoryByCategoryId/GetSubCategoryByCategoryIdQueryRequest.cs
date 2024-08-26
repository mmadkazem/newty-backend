namespace Reservation.Application.Categories.Queries.GetSubCategoryByCategoryId;

public record GetSubCategoriesByCategoryIdQueryRequest(int Id) : IRequest<IEnumerable<IResponse>>
{
    public static implicit operator GetSubCategoriesByCategoryIdQueryRequest(Guid id)
        => new(id);
    public static implicit operator int(GetSubCategoriesByCategoryIdQueryRequest request)
        => request.Id;
}

