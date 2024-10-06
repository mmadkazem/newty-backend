namespace Reservation.Controllers.Finances;


[ApiController]
[Route("api/[controller]")]
[Authorize(Role.User)]
public class UserRequestPaysController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post(int amount,
        CancellationToken token)
    {
        var result = await _sender.Send(new CreateUserRequestPayCommandRequest(User.UserId(), amount), token);
        return Ok(result);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get(Guid Id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetUserRequestPayQueryRequest(User.UserId(), Id), token);
        return Ok(result);
    }

    [HttpGet("Page/{Page:int}/Size/{size:int}")]
    [ProducesResponseType(typeof(Response<GetUserRequestPaysQueryResponse>), 200)]
    public async Task<IActionResult> Get(int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetUserRequestPaysQueryRequest(User.UserId(), page, size), token);
        return Ok(results);
    }
}