namespace Reservation.Controllers.Businesses;


[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class SmsCreditController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post(int count)
    {
        var request = CreateSmsCreditCommandRequest.Create(User.UserId(), count);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(int count)
    {
        var request = UpdateSmsCreditCommandRequest.Create(User.UserId(), count);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _sender.Send(new GetSmsCreditQueryRequest(User.UserId()));
        return Ok();
    }
}