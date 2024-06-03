namespace Reservation.Application.Categories.Commands.CreateSubCategory;


public record CreateSubCategoryCommandRequest
(
    string Title,
    string Description,
    string CoverImagePath
) : IRequest
{
    public Guid CategoryId { get; set; }
}