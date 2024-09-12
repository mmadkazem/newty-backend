namespace Reservation.Application.Posts.Queries.GetPost;

public sealed class GetPostQueryHandler(IUnitOfWork uow, IObjectStorageProvider objectStorage) : IRequestHandler<GetPostQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IObjectStorageProvider _objectStorage = objectStorage;

    public async Task<IResponse> Handle(GetPostQueryRequest request, CancellationToken cancellationToken)
    {
        var response = (GetPostQueryResponse)await _uow.Posts.Get(request.Id, cancellationToken)
            ?? throw new PostNotFoundException();

        response.CoverImagePath = await _objectStorage.GetUrl(response.CoverImagePath);

        return response;
    }
}