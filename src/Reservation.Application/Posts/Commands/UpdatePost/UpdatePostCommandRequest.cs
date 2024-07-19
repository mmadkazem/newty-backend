namespace Reservation.Application.Posts.Commands.UpdatePost;

public record UpdatePostCommandRequest
(
    Guid Id,
    Guid BusinessId,
    string Title,
    string Description,
    string CoverImagePath
) : IRequest
{
    public static UpdatePostCommandRequest Create(Guid id, Guid businessId, UpdatePostDTO model)
        => new(id, businessId, model.Title, model.Description, model.CoverImagePath);
}

public record UpdatePostDTO
(
    string Title,
    string Description,
    string CoverImagePath
);
