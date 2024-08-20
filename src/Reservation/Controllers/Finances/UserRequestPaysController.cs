namespace Reservation.Controllers.Finances;


[ApiController]
[Route("api/[controller]")]
[Authorize(Role.User)]
public class UserRequestPaysController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequestPayCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get(Guid Id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetUserRequestPayQueryRequest(Id), token);
        return Ok(result);
    }

    [HttpGet("Page/{Page:int}")]
    public async Task<IActionResult> Get(int page,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetUserRequestPaysQueryRequest(User.UserId(), page), token);
        return Ok(results);
    }
}