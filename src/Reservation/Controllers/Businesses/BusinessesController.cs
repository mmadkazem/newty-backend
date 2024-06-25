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

    [HttpPost("Points")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] AddBusinessPointDTO model)
    {
        var request = AddBusinessPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{page:int}/Key/{key}")]
    public async Task<IActionResult> Search(int page, string key)
    {
        var request = SearchBusinessRequest.Create(page, key);
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