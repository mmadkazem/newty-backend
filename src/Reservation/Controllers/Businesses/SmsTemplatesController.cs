namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class SmsTemplatesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("Businesses/{BusinessId:guid}")]
    public async Task<IActionResult> Post(Guid BusinessId, CreateSmsTemplateDTO model)
    {
        var request = CreateSmsTemplateCommandRequest.Create(BusinessId, model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> Put(Guid Id, UpdateSmsTemplateDTO model)
    {
        var request = UpdateSmsTemplateCommandRequest.Create(Id, model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("Businesses/{BusinessId:guid}")]
    public async Task<IActionResult> Get([FromRoute] GetSmsTemplatesQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get([FromRoute] GetSmsTemplateQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
}