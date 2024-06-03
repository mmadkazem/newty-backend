namespace Reservation.Application.Categories.Queries.GetCategory;

public record GetCategoryQueryRequest(Guid Id) : IRequest<IResponse>;
