namespace Reservation.Application.Categories.Queries.GetSubCategory;

public record GetSubCategoriesQueryResponse
(
    Guid Id, string Title, string Description,
    string CoverImagePath, double AveragePoint
) : IResponse;