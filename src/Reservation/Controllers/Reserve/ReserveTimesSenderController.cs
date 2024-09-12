namespace Reservation.Controllers.Reserve;


[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public class ReserveTimesSenderController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateReserveTimeSenderDTO model,
        CancellationToken token)
    {
        var request = CreateReserveTimeSenderCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Massage = ReserveTimeSuccessMessage.Created });
    }

    [HttpPut("{id:guid}/State/{state}")]
    public async Task<IActionResult> Put(Guid id, ReserveState state,
        CancellationToken token)
    {
        var request = new UpdateStateReserveTimeSenderCommandRequest(id, User.UserId(), state);
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet("Finished/{finished:bool}/Page/{page:int}/Size/{size:int}")]
    [ProducesResponseType(typeof(Response<GetReserveTimeBusinessSenderQueryResponse>), 200)]
    public async Task<IActionResult> GetUserReserveTime(bool finished, int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetBusinessReserveTimeSenderQueryRequest(page, size, finished, User.UserId()), token);
        return Ok(results);
    }

    [HttpGet("State/{state}/Page/{page:int}/Size/{size:int}")]
    [ProducesResponseType(typeof(Response<GetReserveTimeBusinessSenderQueryResponse>), 200)]
    public async Task<IActionResult> GetBusinessReserveTimeByState(ReserveState state, int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetBusinessReserveTimeSenderByStateQueryRequest(page, size, state, User.UserId()), token);
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetReserveTimeSenderByIdQueryResponse), 200)]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetReserveTimeSenderByIdQueryRequest(id), token);
        return Ok(result);
    }

}