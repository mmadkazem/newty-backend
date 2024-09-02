namespace Reservation.Application.Categories.Queries.SearchCategory;



public sealed record SearchCategoryQueryRequest(string Key) : IRequest<IEnumerable<IResponse>>;


public sealed record SearchCategoryQueryResponse(int Id, string Name, string CoverImagePath) : IResponse;
