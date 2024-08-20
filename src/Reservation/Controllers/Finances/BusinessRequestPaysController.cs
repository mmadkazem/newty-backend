namespace Reservation.Controllers.Finances;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class BusinessRequestPaysController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBusinessRequestPayCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetBusinessRequestPayQueryRequest(id), token);
        return Ok(result);
    }

    [HttpGet("Page/{Page:int}")]
    public async Task<IActionResult> Get(int page,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetBusinessRequestPaysQueryRequest(page, User.UserId()), token);
        return Ok(results);
    }
}