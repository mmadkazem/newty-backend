namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class ServicesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateServiceDTO model,
        CancellationToken token)
    {
        var request = CreateServiceCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = ServiceSuccessMessage.Created });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateServiceDTO model,
        CancellationToken token)
    {
        var request = UpdateServiceCommandRequest.Create(id, User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = ServiceSuccessMessage.Updated });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveServiceCommandRequest(id, User.UserId()), token);
        return Ok(new { Message = ServiceSuccessMessage.Removed });
    }

    [HttpGet("Businesses/{businessId:guid}/Page/{page:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetServicesByBusinessIdQueryResponse), 200)]
    public async Task<IActionResult> GetByBusinessId(Guid businessId, int page,
        CancellationToken token)
    {
        var services = await _sender.Send(new GetServicesByBusinessIdQueryRequest(page, businessId), token);
        return Ok(services);
    }
}