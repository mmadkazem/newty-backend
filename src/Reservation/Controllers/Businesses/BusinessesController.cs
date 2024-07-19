namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
public sealed class BusinessesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegisterBusinessCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPost("Categories")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post(IEnumerable<Guid> categories,
        CancellationToken token)
    {
        var request = AddCategoriesToBusinessCommandRequest.Carate(User.UserId(), categories);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPost("Points")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] AddBusinessPointDTO model,
        CancellationToken token)
    {
        var request = AddBusinessPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet("{page:int}/Key/{key}")]
    public async Task<IActionResult> Search(int page, string key,
        CancellationToken token)
    {
        var request = SearchBusinessRequest.Create(page, key);
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Put([FromBody] UpdateBusinessDTO model,
        CancellationToken token)
    {
        var request = UpdateBusinessCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPatch]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Patch(bool isCancelReserveTime,
        CancellationToken token)
    {
        await _sender.Send(new UpdateIsCancelReserveTimeCommandRequest(User.UserId(), isCancelReserveTime), token);
        return Ok();
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var result = await _sender.Send(new GetBusinessQueryRequest(User.UserId()), token);
        return Ok(result);
    }
}