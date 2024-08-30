namespace Reservation.Application.Posts.Queries.GetPosts;

public sealed class GetPostsQueryHandler(IUnitOfWork uow) : IRequestHandler<GetPostsQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetPostsQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Posts.GetPosts(request.Page, request.Size, request.BusinessId, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}