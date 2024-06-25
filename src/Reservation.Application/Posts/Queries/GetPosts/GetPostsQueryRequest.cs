
namespace Reservation.Application.Posts.Queries.GetPosts;


public record GetPostsQueryRequest(int Page, Guid BusinessId)
    : IRequest<IEnumerable<IResponse>>;

public record GetPostsQueryResponse
(
    Guid Id,
    string Title,
    string CoverImagePath
) : IResponse;
