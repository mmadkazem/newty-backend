
namespace Reservation.Application.Categories.Commands.UpdateSubCategory;


public record UpdateSubCategoryCommandRequest
    (Guid Id, string Title, string Description, string CoverImagePath) : IRequest;
