
namespace Reservation.Application.Posts.Queries.GetPosts;


public record GetPostsQueryRequest(int Page, int Size, Guid BusinessId)
    : IRequest<Response>;

public record GetPostsQueryResponse
(
    Guid Id,
    string Title,
    string CoverImagePath
) : IResponse;
