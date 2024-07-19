namespace Reservation.Application.Categories.Queries.SearchCategory;



public sealed record SearchCategoryQueryRequest(string Key, int Page) : IRequest<IEnumerable<IResponse>>;


public sealed record SearchCategoryQueryResponse(Guid Id, string Name, string CoverImagePath) : IResponse;
