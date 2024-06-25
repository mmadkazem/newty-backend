namespace Reservation.Application.Categories.Queries.GetSubCategoryById;

public record GetSubCategoryByIdQueryResponse
(
    Guid Id,
    string Title,
    string Description,
    string CoverImagePath,
    double AveragePoint
) : IResponse;