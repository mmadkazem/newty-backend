namespace Reservation.Application.Categories.Queries.GetCategory;

public record GetCategoryQueryResponse
(
    int Id, string Title, string Description,
    string CoverImagePath, int? ParentId
) : IResponse;