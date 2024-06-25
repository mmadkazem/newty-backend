namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class ServicesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateServiceDTO model)
    {
        var request = CreateServiceCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("Businesses/{BusinessId:guid}/Page/{Page:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByBusinessId([FromRoute] GetServicesByBusinessIdQueryRequest request)
    {
        var services = await _sender.Send(request);
        return Ok(services);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateServiceDTO model)
    {
        var request = UpdateServiceCommandRequest.Create(id, model);
        await _sender.Send(request);
        return Ok();
    }
}