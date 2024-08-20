namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class ArtistsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateArtistDTO model,
        CancellationToken token)
    {
        var request = CreateArtistCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = ArtistSuccessMessage.Created });
    }

    [HttpPost("Points")]
    [Authorize(Role.User)]
    [Authorize(Role.Business)]
    public async Task<IActionResult> Post([FromBody] AddArtistPointDTO model,
        CancellationToken token)
    {
        var request = AddArtistPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = CommonMessage.PointRecorded });
    }

    [HttpPost("{artistId:guid}/Services/{serviceId:guid}")]
    public async Task<IActionResult> Post(Guid artistId, Guid serviceId,
        CancellationToken token)
    {
        await _sender.Send(new AddServiceCommandRequest(artistId, serviceId), token);
        return Ok(new { Message = ArtistSuccessMessage.ServiceAdded });
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetArtistQueryRequest(id), token);
        return Ok(result);
    }

    [HttpGet("{id:guid}/Services")]
    [AllowAnonymous]
    public async Task<IActionResult> GetArtistService(Guid id,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetArtistServicesQueryRequest(id), token);
        return Ok(results);
    }

    [HttpGet("Businesses/{businessId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetArtistByBusinessId(Guid businessId,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetArtistByBusinessIdQueryRequest(businessId), token);
        return Ok(results);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateArtistDTO model,
        CancellationToken token)
    {
        var request = UpdateArtistCommandRequest.Create(id, User.UserId(), model);
        await _sender.Send(request, token);
        return Ok(new { Message = ArtistSuccessMessage.Updated });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveArtistCommandRequest(id, User.UserId()), token);
        return Ok(new { Message = ArtistSuccessMessage.Removed });
    }
}