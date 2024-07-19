namespace Reservation.Controllers.SmsPlans;


[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.AdminScheme)]
public sealed class SmsPlansController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSmsPlanCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSmsPlanDTO model,
        CancellationToken token)
    {
        var request = UpdateSmsPlanCommandRequest.Create(id, model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveSmsPlanCommandRequest(id), token);
        return Ok();
    }

    [HttpGet("{page:int}")]
    public async Task<IActionResult> Get(int page,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetSmsPlansQueryRequest(page), token);
        return Ok(results);
    }
}