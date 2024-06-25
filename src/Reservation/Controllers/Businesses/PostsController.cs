namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
public sealed class PostsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] CreatePostDTO model)
    {
        var request = CreatePostCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }
    [HttpPut("{Id:guid}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post(Guid Id, [FromBody] UpdatePostDTO model)
    {
        var request = UpdatePostCommandRequest.Create(Id, model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get([FromRoute] GetPostQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpGet("Page/{page:int}/Businesses/{businessId:guid}")]
    public async Task<IActionResult> Get([AsParameters] GetPostsQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
}