namespace Reservation.Controllers.Reserve;


[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public class ReserveTimesSenderController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateReserveTimeSenderDTO model,
        CancellationToken token)
    {
        var request = CreateReserveTimeSenderCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("{id:guid}/State/{state}")]
    public async Task<IActionResult> Put(Guid id, ReserveState state,
        CancellationToken token)
    {
        var request = new UpdateStateReserveTimeSenderCommandRequest(id, User.UserId(), state);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet("Page/{page:int}/Finished/{finished:bool}")]
    public async Task<IActionResult> GetUserReserveTime(int page, bool finished,
        CancellationToken token)
    {
        var request = GetBusinessReserveTimeSenderQueryRequest.Create(page, finished, User.UserId());
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("Page/{page:int}/State/{state}")]
    public async Task<IActionResult> GetBusinessReserveTimeByState(int page, ReserveState state,
        CancellationToken token)
    {
        var request = GetBusinessReserveTimeSenderByStateQueryRequest.Create(page, state, User.UserId());
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

}