namespace Reservation.Application.Categories.Queries.GetTop3Category;

public record GetTop3SubCategoryQueryRequest() : IRequest<IEnumerable<IResponse>>;