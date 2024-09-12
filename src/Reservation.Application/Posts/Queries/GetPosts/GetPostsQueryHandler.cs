namespace Reservation.Application.Posts.Queries.GetPosts;

public sealed class GetPostsQueryHandler(IUnitOfWork uow, IObjectStorageProvider objectStorage) : IRequestHandler<GetPostsQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IObjectStorageProvider _objectStorage = objectStorage;

    public async Task<Response> Handle(GetPostsQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = (IEnumerable<GetPostsQueryResponse>) await _uow.Posts.GetPosts(request.Page, request.Size, request.BusinessId, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }
        foreach (var response in responses)
        {
            var url = await _objectStorage.GetUrl(response.CoverImagePath);
            response.CoverImagePath = url;
        }

        return new Response(false, responses);
    }
}