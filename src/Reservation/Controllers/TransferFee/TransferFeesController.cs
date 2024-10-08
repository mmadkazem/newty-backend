namespace Reservation.Controllers.TransferFee;


[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Admin)]
public class TransferFeesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPut]
    public async Task<IActionResult> Put(int percent,
        CancellationToken token)
    {
        await _sender.Send(new UpdateTransferFeeCommandRequest(percent), token);
        return Ok(new { Message = TransferFeeSuccessMessage.Updated });
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetTransferFeeQueryResponse), 200)]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var result = await _sender.Send(new GetTransferFeeQueryRequest(), token);
        return Ok(result);
    }
}