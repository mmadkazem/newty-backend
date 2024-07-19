namespace Reservation.Application.Categories.Commands.CreateCategory;


public record CreateCategoryCommandRequest
    (string Title, string Description, string CoverImagePath, Guid? ParentId) : IRequest
{
    public static CreateCategoryCommandRequest Create(Guid? parentId, CreateCategoryDTO model)
        => new(model.Title, model.Description, model.CoverImagePath, parentId);
}

public record CreateCategoryDTO(string Title, string Description, string CoverImagePath);