namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
public sealed class ServicesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [Authorize(AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] CreateServiceDTO model)
    {
        var request = CreateServiceCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{BusinessId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByBusinessId([FromRoute] GetServicesByBusinessIdQueryRequest request)
    {
        var services = await _sender.Send(request);
        return Ok(services);
    }

    [HttpPut("{id:guid}")]
    [Authorize(AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateServiceDTO model)
    {
        var request = UpdateServiceCommandRequest.Create(id, model);
        await _sender.Send(request);
        return Ok();
    }
}