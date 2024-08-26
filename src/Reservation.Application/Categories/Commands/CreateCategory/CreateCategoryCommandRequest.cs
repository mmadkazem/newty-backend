namespace Reservation.Application.Categories.Commands.CreateCategory;


public record CreateCategoryCommandRequest
    (string Title, string Description, string CoverImagePath, int? ParentId) : IRequest
{
    public static CreateCategoryCommandRequest Create(int? parentId, CreateCategoryDTO model)
        => new(model.Title, model.Description, model.CoverImagePath, parentId);
}

public record CreateCategoryDTO(string Title, string Description, string CoverImagePath);