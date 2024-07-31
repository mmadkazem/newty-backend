namespace Reservation.Application.Categories.Queries.GetMainCategory;

public record GetMainCategoryQueryRequest() : IRequest<IEnumerable<IResponse>>;