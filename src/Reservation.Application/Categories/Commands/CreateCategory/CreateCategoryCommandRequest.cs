namespace Reservation.Application.Categories.Commands.CreateCategory;


public record CreateCategoryCommandRequest
    (string Title, string Description, string CoverImagePath) : IRequest
{
    public Guid ParentId { get; set; }
    public static CreateCategoryCommandRequest Create(CreateCategoryDTO model)
        => new(model.Title, model.Description, model.CoverImagePath);
}

public record CreateCategoryDTO(string Title, string Description, string CoverImagePath);