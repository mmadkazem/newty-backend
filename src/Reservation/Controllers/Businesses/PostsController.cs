namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class PostsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePostDTO model,
        CancellationToken token)
    {
        var request = CreatePostCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Post(Guid id, [FromBody] UpdatePostDTO model,
        CancellationToken token)
    {
        var request = UpdatePostCommandRequest.Create(id, User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemovePostCommandRequest(id, User.UserId()), token);
        return Ok();
    }

    [HttpGet("{Id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] GetPostQueryRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet("Page/{page:int}/Businesses/{businessId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([AsParameters] GetPostsQueryRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        return Ok(result);
    }
}