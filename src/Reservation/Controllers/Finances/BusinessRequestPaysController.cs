namespace Reservation.Controllers.Finances;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class BusinessRequestPaysController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post(int amount,
        CancellationToken token)
    {
        var result = await _sender.Send(new CreateBusinessRequestPayCommandRequest(User.UserId(), amount), token);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetBusinessRequestPayQueryRequest(id), token);
        return Ok(result);
    }

    [HttpGet("Page/{page:int}/Size/{size:int}")]
    [ProducesResponseType(typeof(Response<GetBusinessRequestPaysQueryResponse>), 200)]
    public async Task<IActionResult> Get(int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetBusinessRequestPaysQueryRequest(page, size, User.UserId()), token);
        return Ok(results);
    }
}