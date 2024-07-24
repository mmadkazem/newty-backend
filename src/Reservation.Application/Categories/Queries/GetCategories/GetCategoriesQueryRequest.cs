namespace Reservation.Application.Categories.Queries.GetCategories;


public record GetCategoriesQueryRequest() : IRequest<IEnumerable<IResponse>>;
