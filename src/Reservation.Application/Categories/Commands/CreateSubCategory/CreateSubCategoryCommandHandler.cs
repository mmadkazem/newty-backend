using Reservation.Domain.Entities.Categories;

namespace Reservation.Application.Categories.Commands.CreateSubCategory;


public sealed class CreateSubCategoryCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateSubCategoryCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await _uow.Categories.FindAsync(request.CategoryId, cancellationToken)
            ?? throw new CategoryNotFoundException();

        SubCategory subCategory = new()
        {
            Title = request.Title,
            Description = request.Description,
            CoverImagePath = request.CoverImagePath,
            Category = category
        };

        _uow.Categories.Add(subCategory);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}