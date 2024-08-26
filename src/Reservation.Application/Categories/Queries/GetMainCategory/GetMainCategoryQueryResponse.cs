namespace Reservation.Application.Categories.Queries.GetMainCategory;

public record GetMainCategoryQueryResponse
(
    int Id, string Title, string Description,
    string CoverImagePath
) : IResponse;
