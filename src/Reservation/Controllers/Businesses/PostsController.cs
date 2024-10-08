namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class PostsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePostDTO model,
        CancellationToken token)
    {
        var request = CreatePostCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = PostSuccessMessage.Created });
    }
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePostDTO model,
        CancellationToken token)
    {
        var request = UpdatePostCommandRequest.Create(id, User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = PostSuccessMessage.Updated });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemovePostCommandRequest(id, User.UserId()), token);
        return Ok(new { Message = PostSuccessMessage.Removed });
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetPostQueryResponse), 200)]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetPostQueryRequest(id), token);
        return Ok(result);
    }

    [HttpGet("Businesses/{businessId:guid}/Page/{page:int}/Size/{size:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(Response<GetPostsQueryResponse>), 200)]
    public async Task<IActionResult> Get(Guid businessId, int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetPostsQueryRequest(page, size, businessId), token);
        return Ok(results);
    }
}