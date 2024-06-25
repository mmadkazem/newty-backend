namespace Reservation.Application.Posts.Commands.CreatePost;

public record CreatePostCommandRequest
(
    Guid BusinessId,
    string Title,
    string Description,
    string CoverImagePath
) : IRequest
{
    public static CreatePostCommandRequest Create(Guid businessId, CreatePostDTO model)
        => new(businessId, model.Title, model.Description, model.CoverImagePath);
}

public record CreatePostDTO
(
    string Title,
    string Description,
    string CoverImagePath
);
