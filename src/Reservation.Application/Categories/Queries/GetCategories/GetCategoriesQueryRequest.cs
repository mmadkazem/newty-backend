namespace Reservation.Application.Categories.Queries.GetCategories;


public record GetCategoriesQueryRequest(int Page) : IRequest<IEnumerable<IResponse>>;
