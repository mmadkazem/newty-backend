namespace Reservation.Controllers.Businesses;


[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class SmsCreditController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post(int count,
        CancellationToken token)
    {
        var request = CreateSmsCreditCommandRequest.Create(User.UserId(), count);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("Found")]
    public async Task<IActionResult> Put(Guid SMSPlanId,
        CancellationToken token)
    {
        var request = FoundSmsCreditCommandRequest.Create(User.UserId(), SMSPlanId);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        await _sender.Send(new GetSmsCreditQueryRequest(User.UserId()), token);
        return Ok();
    }
}