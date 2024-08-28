namespace Reservation.Controllers.Businesses;


[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class SmsCreditController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post(int count,
        CancellationToken token)
    {
        var request = CreateSmsCreditCommandRequest.Create(User.UserId(), count);
        await _sender.Send(request, token);
        return Ok(new { Message = SmsCreditSuccessMessage.Created });
    }

    [HttpPut("Found")]
    public async Task<IActionResult> Put(Guid SMSPlanId,
        CancellationToken token)
    {
        var request = FoundSmsCreditCommandRequest.Create(User.UserId(), SMSPlanId);
        await _sender.Send(request, token);
        return Ok(new { Message = SmsCreditSuccessMessage.Founded });
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetSmsCreditQueryResponse), 200)]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var result = await _sender.Send(new GetSmsCreditQueryRequest(User.UserId()), token);
        return Ok(result);
    }
}