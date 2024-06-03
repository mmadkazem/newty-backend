namespace Reservation.Application.Categories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateSubCategoryCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var subCategory = await _uow.Categories.FindAsync(request.Id, cancellationToken)
            ?? throw new CategoryNotFoundException();

        if (subCategory.Title != request.Title && !await _uow.Categories.AnyAsync(request.Title, cancellationToken))
        {
            throw new TitleAlreadyExistException();
        }

        subCategory.Title = request.Title;
        subCategory.Description = request.Description;
        subCategory.CoverImagePath = request.CoverImagePath;
        subCategory.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}