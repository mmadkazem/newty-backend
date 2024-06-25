namespace Reservation.Controllers.Finances;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class BusinessRequestPaysController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBusinessRequestPayCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateBusinessRequestPayDTO model)
    {
        var request = UpdateBusinessRequestPayCommandRequest.Create(id, model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get([FromRoute] GetBusinessRequestPayQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpGet("Businesses/{BusinessId:guid}/Page/{Page:int}")]
    public async Task<IActionResult> Get([FromRoute] GetBusinessRequestPaysQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }
}