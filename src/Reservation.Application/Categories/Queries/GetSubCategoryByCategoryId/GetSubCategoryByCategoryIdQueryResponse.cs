namespace Reservation.Application.Categories.Queries.GetSubCategoryByCategoryId;

public record GetSubCategoriesByCategoryIdQueryResponse
(
    Guid Id, string Title,
    string Description,
    string CoverImagePath,
    int AveragePoint
) : IResponse;