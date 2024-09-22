using Reservation.Application.Finances.BusinessRequestWithdraws.Commands.UpdateRequestWithdraw;
using Reservation.Application.Finances.BusinessRequestWithdraws.Queries.GetBusinessRequestWithdraw;

namespace Reservation.Controllers.Finances;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Admin)]
public sealed class BusinessRequestWithdrawController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPut("{id:guid}/Businesses/{businessId:guid}")]
    public async Task<IActionResult> Put(Guid id, Guid businessId,
        CancellationToken token = default)
    {
        await _sender.Send(new UpdateRequestWithdrawCommandRequest(id, businessId), token);
        return Ok();
    }

    [HttpGet("Page/{page:int}/Size/{size:int}")]
    [ProducesResponseType(typeof(Response<GetBusinessRequestWithdrawQueryResponse>), 200)]
    public async Task<IActionResult> Get(int page, int size,
        CancellationToken token = default)
    {
        var result = await _sender.Send(new GetBusinessRequestWithdrawQueryRequest(page, size), token);
        return Ok(result);
    }
}