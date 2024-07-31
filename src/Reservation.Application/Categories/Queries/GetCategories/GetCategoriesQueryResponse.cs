namespace Reservation.Application.Categories.Queries.GetCategories;

public record GetCategoriesQueryResponse
(
    Guid Id, string Title, string Description,
    string CoverImagePath, Guid? ParentId
) : IResponse;