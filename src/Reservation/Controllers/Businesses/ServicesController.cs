namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class ServicesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateServiceDTO model,
        CancellationToken token)
    {
        var request = CreateServiceCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet("Businesses/{BusinessId:guid}/Page/{Page:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByBusinessId([FromRoute] GetServicesByBusinessIdQueryRequest request,
        CancellationToken token)
    {
        var services = await _sender.Send(request, token);
        return Ok(services);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateServiceDTO model,
        CancellationToken token)
    {
        var request = UpdateServiceCommandRequest.Create(id, User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveServiceCommandRequest(id, User.UserId()), token);
        return Ok();
    }
}