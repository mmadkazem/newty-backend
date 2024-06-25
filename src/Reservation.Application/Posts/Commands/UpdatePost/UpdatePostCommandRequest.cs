namespace Reservation.Application.Posts.Commands.UpdatePost;

public record UpdatePostCommandRequest
(
    Guid Id,
    string Title,
    string Description,
    string CoverImagePath
) : IRequest
{
    public static UpdatePostCommandRequest Create(Guid Id, UpdatePostDTO model)
        => new(Id, model.Title, model.Description, model.CoverImagePath);
}

public record UpdatePostDTO
(
    string Title,
    string Description,
    string CoverImagePath
);
