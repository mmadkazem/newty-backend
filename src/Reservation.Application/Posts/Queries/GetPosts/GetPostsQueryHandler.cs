
namespace Reservation.Application.Posts.Queries.GetPosts;

public sealed class GetPostsQueryHandler(IUnitOfWork uow) : IRequestHandler<GetPostsQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetPostsQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Posts.GetPosts(request.Page, request.BusinessId, cancellationToken);
        if (!responses.Any())
        {
            throw new PostNotFoundException();
        }
        return responses;
    }
}