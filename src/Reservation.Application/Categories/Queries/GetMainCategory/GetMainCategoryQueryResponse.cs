namespace Reservation.Application.Categories.Queries.GetMainCategory;

public record GetMainCategoryQueryResponse
(
    Guid Id, string Title, string Description,
    string CoverImagePath
) : IResponse;
