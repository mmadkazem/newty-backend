
namespace Reservation.Application.Categories.Commands.AddCategoryPoint;


public record AddCategoryPointCommandRequest(Guid CategoryId, Guid UserId, int Rate) : IRequest
{
    public static AddCategoryPointCommandRequest Create(Guid userId, AddCategoryPointDTO model)
        => new(userId, model.CategoryId, model.Rate);
}

public record AddCategoryPointDTO(Guid CategoryId, int Rate);
