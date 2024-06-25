namespace Reservation.Application.Posts.Commands.CreatePost;

public sealed class CreatePostCommandHandler(IUnitOfWork uow) : IRequestHandler<CreatePostCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessesNotFoundException();

        Post post = new()
        {
            Title = request.Title,
            Description = request.Description,
            CoverImagePath = request.CoverImagePath,
            Business = business
        };

        _uow.Posts.Add(post);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}