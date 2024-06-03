namespace Reservation.Application.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandHandler(IUnitOfWork uow)
    : IRequestHandler<UpdateCategoryCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await _uow.Categories.FindAsync(request.Id, cancellationToken)
            ?? throw new CategoryNotFoundException();
        if (category.Title != request.Title && !await _uow.Categories.AnyAsync(request.Title, cancellationToken))
        {
            throw new TitleAlreadyExistException();
        }

        category.Title = request.Title;
        category.Description = request.Description;
        category.CoverImagePath = request.CoverImagePath;
        category.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}
