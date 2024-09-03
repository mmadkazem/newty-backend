namespace Reservation.Application.Posts.Commands.RemovePost;

public sealed class RemovePostCommandHandler(IUnitOfWork uow) : IRequestHandler<RemovePostCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemovePostCommandRequest request, CancellationToken cancellationToken)
    {
        var post = await _uow.Posts.FindAsync(request.Id, cancellationToken)
            ?? throw new PostNotFoundException();

        post.Business.IsValidate();

        if (post.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToChangeItemException("پست");
        }

        _uow.Posts.Remove(post);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}