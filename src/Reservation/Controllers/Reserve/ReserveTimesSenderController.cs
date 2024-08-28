using Reservation.Application.ReserveTimes.Queries.GetReserveSenderTime;

namespace Reservation.Controllers.Reserve;


[ApiController]
[Route("api/[controller]")]
public class ReserveTimesSenderController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [Authorize(Role.Business)]
    public async Task<IActionResult> Post([FromBody] CreateReserveTimeSenderDTO model,
        CancellationToken token)
    {
        var request = CreateReserveTimeSenderCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Massage = ReserveTimeSuccessMessage.Created });
    }

    [HttpPut("{id:guid}/State/{state}")]
    [Authorize(Role.Business)]
    public async Task<IActionResult> Put(Guid id, ReserveState state,
        CancellationToken token)
    {
        var request = new UpdateStateReserveTimeSenderCommandRequest(id, User.UserId(), state);
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet("Finished/{finished:bool}/Page/{page:int}")]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(GetReserveTimeBusinessSenderQueryResponse), 200)]
    public async Task<IActionResult> GetUserReserveTime(bool finished, int page,
        CancellationToken token)
    {
        var request = GetBusinessReserveTimeSenderQueryRequest.Create(page, finished, User.UserId());
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("State/{state}/Page/{page:int}")]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(GetReserveTimeBusinessSenderQueryResponse), 200)]
    public async Task<IActionResult> GetBusinessReserveTimeByState(ReserveState state, int page,
        CancellationToken token)
    {
        var request = GetBusinessReserveTimeSenderByStateQueryRequest.Create(page, state, User.UserId());
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Role.BusinessUser)]
    [ProducesResponseType(typeof(GetReserveTimeSenderByIdQueryResponse), 200)]
    public async Task<IActionResult> Get([AsParameters] GetReserveTimeSenderByIdQueryRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

}