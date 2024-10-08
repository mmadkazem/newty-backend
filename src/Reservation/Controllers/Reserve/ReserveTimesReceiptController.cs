namespace Reservation.Controllers.Reserve;

[ApiController]
[Route("api/[controller]")]
public sealed class ReserveTimesReceiptController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("Wallet")]
    [Authorize(Role.User)]
    public async Task<IActionResult> PostWithWallet([FromBody] CreateReserveTimeReceiptDTO model,
        CancellationToken token)
    {
        var request = CreateReserveTimeReceiptCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = ReserveTimeSuccessMessage.Created });
    }

    [HttpPost("Direct")]
    [Authorize(Role.User)]
    [ProducesResponseType<string>(200)]
    public async Task<IActionResult> PostWithDirect([FromBody] CreateReserveTimeWithDirectPaymentDTO model,
        CancellationToken token)
    {
        var request = CreateReserveTimeWithDirectPaymentCommandRequest.Create(User.UserId(), model);
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpPut("{id:guid}/Verify")]
    [ProducesResponseType<string>(200)]
    public async Task<IActionResult> Verify(Guid id, string authority,
        CancellationToken token)
    {
        var result = await _sender.Send(new VerifyReserveTimeCommandRequest(id, authority), token);
        return Redirect(result);
    }

    [HttpPut("{id:guid}/State/{state}")]
    [Authorize(Roles = Role.BusinessUser)]
    public async Task<IActionResult> Put(Guid id, ReserveState state,
        CancellationToken token)
    {
        var request = new UpdateStateReserveTimeReceiptCommandRequest(id, state, User.Roles(), User.UserId());
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet("Businesses/Finished/{finished:bool}/Page/{page:int}/Size/{size:int}")]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(Response<GetReserveTimeBusinessReceiptQueryResponse>), 200)]
    public async Task<IActionResult> GetBusinessReserveTime(bool finished, int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetBusinessReserveTimeReceiptQueryRequest(page, size, User.UserId(), finished), token);
        return Ok(results);
    }

    [HttpGet("Businesses/State/{state}/Page/{page:int}/Size/{size:int}")]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(Response<GetReserveTimeBusinessReceiptQueryResponse>), 200)]
    public async Task<IActionResult> GetBusinessReserveTimeByState(ReserveState state, int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetBusinessReserveTimeByStateReceiptQueryRequest(page, size, state, User.UserId()), token);
        return Ok(results);
    }

    [HttpGet("Businesses/{businessId:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetFreeTimeQueryResponse), 200)]
    public async Task<IActionResult> GetBusinessFreeTimes(Guid businessId,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetFreeTimeQueryRequest(businessId), token);
        return Ok(results);
    }

    [HttpGet("Users/Finished/{finished:bool}/Page/{page:int}/Size/{size:int}")]
    [Authorize(Role.User)]
    [ProducesResponseType(typeof(Response<GetReserveTimeUserQueryResponse>), 200)]
    public async Task<IActionResult> GetUserReserveTime(bool finished, int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetUserReserveTimeQueryRequest(page, size, User.UserId(), finished), token);
        return Ok(results);
    }

    [HttpGet("Users/State/{state}/Page/{page:int}/Size/{size:int}")]
    [Authorize(Role.User)]
    [ProducesResponseType(typeof(Response<GetReserveTimeUserQueryResponse>), 200)]
    public async Task<IActionResult> GetUserReserveTimeByState(ReserveState state, int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetUserReserveTimeByStateQueryRequest(page, size, User.UserId(), state), token);
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(GetReserveTimeDetailQueryResponse), 200)]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetReserveTimeByIdReceiptQueryRequest(id), token);
        return Ok(result);
    }
}