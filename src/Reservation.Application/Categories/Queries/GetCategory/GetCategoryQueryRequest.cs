namespace Reservation.Application.Categories.Queries.GetCategory;

public record GetCategoryQueryRequest(int Id) : IRequest<IResponse>;
