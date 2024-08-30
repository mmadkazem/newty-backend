namespace Reservation.Controllers.SmsPlans;


[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Admin)]
public sealed class SmsPlansController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSmsPlanCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok(new { Message = SmsPlanSuccessMessage.Created });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSmsPlanDTO model,
        CancellationToken token)
    {
        var request = UpdateSmsPlanCommandRequest.Create(id, model);
        await _sender.Send(request, token);
        return Ok(new { Message = SmsPlanSuccessMessage.Updated });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveSmsPlanCommandRequest(id), token);
        return Ok(new { Message = SmsPlanSuccessMessage.Removed });
    }

    [HttpGet("{page:int}/Size/{size:int}")]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(Response<GetSmsPlansQueryResponse>), 200)]
    public async Task<IActionResult> Get(int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetSmsPlansQueryRequest(page, size), token);
        return Ok(results);
    }
}