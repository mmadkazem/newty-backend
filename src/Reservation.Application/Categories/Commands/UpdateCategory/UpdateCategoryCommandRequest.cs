namespace Reservation.Application.Categories.Commands.UpdateCategory;


public record UpdateCategoryCommandRequest
    (int Id, string Title, string Description, string CoverImagePath) : IRequest
{
    public static UpdateCategoryCommandRequest Create(int Id, UpdateCategoryDTO model)
        => new(Id, model.Title, model.Description, model.CoverImagePath);
}

public record UpdateCategoryDTO(string Title, string Description, string CoverImagePath);
