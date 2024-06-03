namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
public sealed class BusinessesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegisterBusinessCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{Page:int}/Key/{Key}")]
    public async Task<IActionResult> Search([FromQuery] SearchBusinessRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Put([FromBody] UpdateBusinessDTO model)
    {
        var request = UpdateBusinessCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }
}