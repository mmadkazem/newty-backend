namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class SmsTemplatesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("Businesses/{BusinessId:guid}")]
    public async Task<IActionResult> Post(Guid BusinessId, CreateSmsTemplateDTO model,
        CancellationToken token)
    {
        var request = CreateSmsTemplateCommandRequest.Create(BusinessId, model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateSmsTemplateDTO model,
        CancellationToken token)
    {
        var request = UpdateSmsTemplateCommandRequest.Create(id, User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveSmsTemplateCommandRequest(id, User.UserId()), token);
        return Ok();
    }

    [HttpGet("Businesses/{businessId:guid}")]
    public async Task<IActionResult> GetAll(Guid businessId,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetSmsTemplatesQueryRequest(businessId), token);
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetSmsTemplateQueryRequest(id), token);
        return Ok(result);
    }
}