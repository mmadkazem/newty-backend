namespace Reservation.Controllers.Reserve;

[ApiController]
[Route("api/[controller]")]
public sealed class ReserveTimesReceiptController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> Post([FromBody] CreateReserveTimeReceiptDTO model,
        CancellationToken token)
    {
        var request = CreateReserveTimeReceiptCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("{id:guid}/State/{state}")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Put(Guid id, ReserveState state,
        CancellationToken token)
    {
        var request = new UpdateStateReserveTimeReceiptCommandRequest(id, state, User.Roles());
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet("Businesses/Finished/{finished:bool}/Page/{page:int}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> GetBusinessReserveTime(bool finished, int page, 
        CancellationToken token)
    {
        var request = GetBusinessReserveTimeReceiptQueryRequest.Create(page, User.UserId(), finished);
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("Businesses/{businessId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBusinessFreeTimes(Guid businessId,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetFreeTimeQueryRequest(businessId), token);
        return Ok(results);
    }

    [HttpGet("Users/Finished/{finished:bool}Page/{page:int}/")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> GetUserReserveTime(bool finished, int page,
        CancellationToken token)
    {
        var request = GetUserReserveTimeQueryRequest.Create(page, User.UserId(), finished);
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("Businesses/State/{state}/Page/{page:int}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> GetBusinessReserveTimeByState(ReserveState state, int page,
        CancellationToken token)
    {
        var request = GetBusinessReserveTimeByStateReceiptQueryRequest.Create(page, state, User.UserId());
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("Users/State/{state}/Page/{page:int}")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> GetUserReserveTimeByState(ReserveState state, int page,
        CancellationToken token)
    {
        var request = GetUserReserveTimeByStateQueryRequest.Create(page, User.UserId(), state);
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> Get([AsParameters] GetReserveTimeByIdReceiptQueryRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        return Ok(result);
    }
}