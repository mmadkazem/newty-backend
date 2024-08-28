using Reservation.Application.Businesses.Commands.UpdateBusinessState;

namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class BusinessesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] RegisterBusinessCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPost("SendSMS")]
    public async Task<IActionResult> SendSMS(DateTime sendDate, Guid templateId,
        CancellationToken token)
    {
        await _sender.Send(new SendSMSUserVIPCommandRequest(User.UserId(), templateId, sendDate), token);
        return Accepted(new { Message = BusinessSuccessMessage.SendedSms });
    }

    [HttpPost("UserVIP")]
    public async Task<IActionResult> PostUserVIP(Guid userId,
    CancellationToken token)
    {
        await _sender.Send(new AddUserVIPCommandRequest(User.UserId(), userId), token);
        return Ok(new { Message = BusinessSuccessMessage.SendedSms });
    }

    [HttpPost("Categories")]
    public async Task<IActionResult> Post(IEnumerable<int> categories,
        CancellationToken token)
    {
        var request = AddCategoriesToBusinessCommandRequest.Carate(User.UserId(), categories);
        await _sender.Send(request, token);
        return Ok(new { Message = BusinessSuccessMessage.CategoryAdded });
    }

    [HttpPost("Points")]
    [Authorize(Role.BusinessUser)]
    public async Task<IActionResult> Post([FromBody] AddBusinessPointDTO model,
        CancellationToken token)
    {
        var request = AddBusinessPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = CommonMessage.PointRecorded });
    }

    [HttpPut]
    [Authorize(Role.Business, AuthenticationSchemes = AuthScheme.UpdateScheme)]
    public async Task<IActionResult> Put([FromBody] UpdateBusinessDTO model,
        CancellationToken token)
    {
        var request = UpdateBusinessCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = BusinessSuccessMessage.Updated });
    }

    [HttpPatch]
    [Authorize(Role.Business)]
    public async Task<IActionResult> Patch(bool isCancelReserveTime,
        CancellationToken token)
    {
        await _sender.Send(new UpdateIsCancelReserveTimeCommandRequest(User.UserId(), isCancelReserveTime), token);
        return Ok(new { Message = BusinessSuccessMessage.Updated });
    }

    [HttpPatch("Businesses/{businessId:guid}/IsValid/{IsValid:bool}")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> Patch(Guid businessId, bool IsValid,
        CancellationToken token)
    {
        await _sender.Send(new UpdateBusinessStateCommandRequest(User.UserId(), IsValid), token);
        return Ok();
    }

    [HttpGet]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(GetBusinessQueryResponse), 200)]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var result = await _sender.Send(new GetBusinessQueryRequest(User.UserId()), token);
        return Ok(result);
    }


    [HttpGet("Page/{page:int}")]
    [Authorize(Role.Admin)]
    [ProducesResponseType(typeof(GetBusinessesWaitingValidQueryResponse), 200)]
    public async Task<IActionResult> GetWaitingValidBusiness(int page,
        CancellationToken token)
    {
        var responses = await _sender.Send(new GetBusinessesWaitingValidQueryRequest(page));
        return Ok(responses);
    }

    [HttpGet("Key/{key}/City/{city}/Page/{page:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SearchBusinessQueryResponse), 200)]
    public async Task<IActionResult> Search(string key, int page, string city,
        CancellationToken token)
    {
        var results = await _sender.Send( new SearchBusinessQueryRequest(page, key, city), token);
        return Ok(results);
    }
}