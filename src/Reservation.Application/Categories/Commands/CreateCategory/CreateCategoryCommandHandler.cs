namespace Reservation.Application.Categories.Commands.CreateCategory;


public sealed class CreateCategoryCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateCategoryCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var parentIdString = request.ParentId.ToString();
        Category category = new()
        {
            Title = request.Title,
            Description = request.Description,
            CoverImagePath = request.CoverImagePath,
        };

        if (parentIdString is not null)
        {
            var parentId = Guid.Parse(parentIdString);

            var parentCategory = await _uow.Categories.FindAsync(parentId, cancellationToken)
                ?? throw new CategoryNotFoundException();

            category.ParentCategory = parentCategory;
        }

        _uow.Categories.Add(category);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}