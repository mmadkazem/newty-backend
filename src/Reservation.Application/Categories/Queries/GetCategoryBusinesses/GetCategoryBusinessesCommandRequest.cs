namespace Reservation.Application.Categories.Queries.GetCategoryBusinesses;


public sealed record GetCategoryBusinessesQueryRequest(int CategoryId, int Page) : IRequest<IEnumerable<IResponse>>;

public sealed record GetCategoryBusinessesQueryResponse
(
    Guid Id, string Name,
    string CoverImagePath,
    bool IsClose,
    string Address,
    double Point
) : IResponse;
