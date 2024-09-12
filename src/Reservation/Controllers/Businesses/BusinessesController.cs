using Reservation.Application.Businesses.Commands.ValidateBusiness;

namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
public sealed class BusinessesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegisterBusinessCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPost("SendSMS")]
    [Authorize(Role.Business)]
    public async Task<IActionResult> SendSMS(DateTime sendDate, Guid templateId,
        CancellationToken token)
    {
        await _sender.Send(new SendSMSUserVIPCommandRequest(User.UserId(), templateId, sendDate), token);
        return Accepted(new { Message = BusinessSuccessMessage.SendedSms });
    }

    [HttpPost("UserVIP")]
    [Authorize(Role.Business)]
    public async Task<IActionResult> PostUserVIP(Guid userId,
    CancellationToken token)
    {
        await _sender.Send(new AddUserVIPCommandRequest(User.UserId(), userId), token);
        return Ok(new { Message = BusinessSuccessMessage.SendedSms });
    }

    [HttpPost("Categories")]
    [Authorize(Role.Business)]
    public async Task<IActionResult> Post(IEnumerable<int> categories,
        CancellationToken token)
    {
        var request = AddCategoriesToBusinessCommandRequest.Carate(User.UserId(), categories);
        await _sender.Send(request, token);
        return Ok(new { Message = BusinessSuccessMessage.CategoryAdded });
    }

    [HttpPost("Points")]
    [Authorize(Roles = Role.BusinessUser)]
    public async Task<IActionResult> Post([FromBody] AddBusinessPointDTO model,
        CancellationToken token)
    {
        var request = AddBusinessPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = CommonMessage.PointRecorded });
    }

    [HttpPut("Validate")]
    [Authorize(Role.Business, AuthenticationSchemes = AuthScheme.InvalidScheme)]
    public async Task<IActionResult> Validate([FromBody] ValidateBusinessDTO model,
        CancellationToken token)
    {
        var request = ValidateBusinessCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = BusinessSuccessMessage.WaitingValidate });
    }
    [HttpPut]
    [Authorize(Role.Business, AuthenticationSchemes = AuthScheme.InvalidScheme)]
    public async Task<IActionResult> Put([FromBody] UpdateBusinessDTO model,
        CancellationToken token)
    {
        var request = UpdateBusinessCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = BusinessSuccessMessage.Updated });
    }
    [HttpPatch]
    [Authorize(Role.Business, AuthenticationSchemes = AuthScheme.InvalidScheme)]
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
        await _sender.Send(new UpdateBusinessStateCommandRequest(businessId, IsValid), token);
        return Ok(new { Message = BusinessSuccessMessage.Validated });
    }

    [HttpGet]
    [Authorize(Role.Business, AuthenticationSchemes = AuthScheme.InvalidScheme)]
    [ProducesResponseType(typeof(GetBusinessQueryResponse), 200)]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var result = await _sender.Send(new GetBusinessQueryRequest(User.UserId()), token);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetBusinessByIdQueryResponse), 200)]
    public async Task<IActionResult> GetBusinessById(Guid id, CancellationToken token)
    {
        var result = await _sender.Send(new GetBusinessByIdQueryRequest(id), token);
        return Ok(result);
    }


    [HttpGet("Page/{page:int}/Size/{size:int}")]
    [Authorize(Role.Admin)]
    [ProducesResponseType(typeof(Response<GetBusinessesWaitingValidItemQueryResponse>), 200)]
    public async Task<IActionResult> GetWaitingValidBusiness(int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetBusinessesWaitingValidQueryRequest(page, size), token);
        return Ok(results);
    }

    [HttpGet("Key/{key}/City/{city}/Page/{page:int}/Size/{size:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(Response<SearchBusinessQueryResponse>), 200)]
    public async Task<IActionResult> Search(string key, int page, int size, string city,
        CancellationToken token)
    {
        var results = await _sender.Send(new SearchBusinessQueryRequest(page, size, key, city), token);
        return Ok(results);
    }
}