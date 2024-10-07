namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class SmsTemplatesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("Businesses")]
    public async Task<IActionResult> Post(CreateSmsTemplateDTO model,
        CancellationToken token)
    {
        var request = CreateSmsTemplateCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = SmsTemplateSuccessMessage.Created });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateSmsTemplateDTO model,
        CancellationToken token)
    {
        var request = UpdateSmsTemplateCommandRequest.Create(id, User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = SmsTemplateSuccessMessage.Updated });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveSmsTemplateCommandRequest(id, User.UserId()), token);
        return Ok(new { Message = SmsTemplateSuccessMessage.Removed });
    }

    [HttpGet("Businesses")]
    [ProducesResponseType(typeof(Response<GetSmsTemplatesQueryResponse>), 200)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var results = await _sender.Send(new GetSmsTemplatesQueryRequest(User.UserId()), token);
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetSmsTemplateQueryResponse), 200)]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetSmsTemplateQueryRequest(id), token);
        return Ok(result);
    }
}