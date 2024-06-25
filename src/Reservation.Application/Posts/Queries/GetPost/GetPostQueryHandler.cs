
namespace Reservation.Application.Posts.Queries.GetPost;

public sealed class GetPostQueryHandler(IUnitOfWork uow) : IRequestHandler<GetPostQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetPostQueryRequest request, CancellationToken cancellationToken)
    {
        IResponse response = await _uow.Posts.Get(request.Id, cancellationToken)
            ?? throw new PostNotFoundException();

        return response;
    }
}