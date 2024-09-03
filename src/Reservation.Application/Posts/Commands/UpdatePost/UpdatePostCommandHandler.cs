namespace Reservation.Application.Posts.Commands.UpdatePost;

public sealed class UpdatePostCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdatePostCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
    {
        var post = await _uow.Posts.FindAsync(request.Id, cancellationToken)
            ?? throw new PostNotFoundException();

        post.Business.IsValidate();

        if (post.Title != request.Title && await _uow.Posts.AnyAsync(request.Title, cancellationToken))
        {
            throw new TitleAlreadyExistException();
        }

        if (post.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToChangeItemException("پست");
        }

        post.Title = request.Title;
        post.Description = request.Description;
        post.CoverImagePath = request.CoverImagePath;
        post.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}