namespace Reservation.Controllers.Reserve;

[ApiController]
[Route("api/[controller]")]
public sealed class ReserveTimesReceiptController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> Post([FromBody] CreateReserveTimeReceiptDTO model)
    {
        var request = CreateReserveTimeReceiptCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateStateReserveTimeReceiptDTO model)
    {
        var request = UpdateStateReserveTimeReceiptCommandRequest.Create(id, model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("Businesses/Page/{page:int}/Finished/{finished:bool}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> GetBusinessReserveTime(int page, bool finished)
    {
        var request = GetBusinessReserveTimeReceiptQueryRequest.Create(page, User.UserId(), finished);
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("Businesses/{BusinessId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBusinessFreeTimes([FromRoute] GetFreeTimeQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("Users/Page/{page:int}/Finished/{finished:bool}")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> GetUserReserveTime(int page, bool finished)
    {
        var request = GetUserReserveTimeQueryRequest.Create(page, User.UserId(), finished);
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("Businesses/Page/{page:int}/State/{state}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> GetBusinessReserveTimeByState(int page, ReserveState state)
    {
        var request = GetBusinessReserveTimeByStateReceiptQueryRequest.Create(page, state, User.UserId());
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("Users/Page/{page:int}/State/{state}")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> GetUserReserveTimeByState(int page, ReserveState state)
    {
        var request = GetUserReserveTimeByStateQueryRequest.Create(page, User.UserId(), state);
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> Get([AsParameters] GetReserveTimeByIdReceiptQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
}