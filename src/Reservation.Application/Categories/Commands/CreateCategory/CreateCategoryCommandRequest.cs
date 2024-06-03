namespace Reservation.Application.Categories.Commands.CreateCategory;


public record CreateCategoryCommandRequest
    (string Title, string Description, string CoverImagePath) : IRequest;