namespace Reservation.Controllers.Reserve;


[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public class ReserveTimesSenderController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateReserveTimeSenderDTO model)
    {
        var request = CreateReserveTimeSenderCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateStateReserveTimeSenderDTO model)
    {
        var request = UpdateStateReserveTimeSenderCommandRequest.Create(id, model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("Page/{page:int}/Finished/{finished:bool}")]
    public async Task<IActionResult> GetUserReserveTime(int page, bool finished)
    {
        var request = GetBusinessReserveTimeSenderQueryRequest.Create(page, finished, User.UserId());
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("Page/{page:int}/State/{state}")]
    public async Task<IActionResult> GetBusinessReserveTimeByState(int page, ReserveState state)
    {
        var request = GetBusinessReserveTimeSenderByStateQueryRequest.Create(page, state, User.UserId());
        var results = await _sender.Send(request);
        return Ok(results);
    }

}