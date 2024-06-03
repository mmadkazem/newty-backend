namespace Reservation.Application.Categories.Queries.GetCategory;

public record GetCategoryQueryResponse
(
    Guid Id, string Title, string Description,
    string CoverImagePath, int AveragePoint
) : IResponse;