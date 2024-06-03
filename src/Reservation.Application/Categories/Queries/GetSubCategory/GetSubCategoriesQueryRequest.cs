namespace Reservation.Application.Categories.Queries.GetSubCategory;


public record GetSubCategoriesQueryRequest(int Page) : IRequest<IEnumerable<IResponse>>;
