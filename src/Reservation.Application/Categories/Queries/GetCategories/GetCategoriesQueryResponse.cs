namespace Reservation.Application.Categories.Queries.GetCategories;

public record GetCategoriesQueryResponse
(
    int Id, string Title, string Description,
    string CoverImagePath, int? ParentId
) : IResponse;