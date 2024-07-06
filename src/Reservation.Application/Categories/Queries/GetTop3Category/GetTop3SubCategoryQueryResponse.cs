namespace Reservation.Application.Categories.Queries.GetTop3Category;

public record GetTop3SubCategoryQueryResponse
(
    Guid Id, string Title, string Description,
    string CoverImagePath, double? AveragePoint
) : IResponse;
