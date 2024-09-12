namespace Reservation.Application.Posts.Queries.GetPost;


public record GetPostQueryRequest(Guid Id) : IRequest<IResponse>;

public class GetPostQueryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string CoverImagePath { get; set; }
    public string Description { get; set; }
    public GetPostQueryResponse(Guid id, string title, string coverImagePath, string description)
    {
        Id = id;
        Title = title;
        CoverImagePath = coverImagePath;
        Description = description;
    }
}
