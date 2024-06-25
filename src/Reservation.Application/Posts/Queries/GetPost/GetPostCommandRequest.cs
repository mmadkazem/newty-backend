
namespace Reservation.Application.Posts.Queries.GetPost;


public record GetPostQueryRequest(Guid Id) : IRequest<IResponse>;

public record GetPostQueryResponse
(
    Guid Id, string Title,
    string Description, string CoverImagePath
) : IResponse;
