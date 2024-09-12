namespace Reservation.Application.Posts.Queries.GetPosts;


public record GetPostsQueryRequest(int Page, int Size, Guid BusinessId)
    : IRequest<Response>;

public class GetPostsQueryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string CoverImagePath { get; set; }
    public GetPostsQueryResponse(Guid id, string title, string coverImagePath)
    {
        Id = id;
        Title = title;
        CoverImagePath = coverImagePath;
    }
}
