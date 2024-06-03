namespace Reservation.Application.Categories.Queries.GetSubCategoryById;


public record GetSubCategoryByIdQueryRequest(Guid Id) : IRequest<IResponse>;
