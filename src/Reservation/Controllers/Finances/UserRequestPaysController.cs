namespace Reservation.Controllers.Finances;


[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
public class UserRequestPaysController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequestPayCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserRequestPayDTO model)
    {
        var request = UpdateUserRequestPayCommandRequest.Create(id, model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get([FromRoute] GetUserRequestPayQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpGet("Users/{UserId:guid}/Page/{Page:int}")]
    public async Task<IActionResult> Get([FromRoute] GetUserRequestPaysQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }
}