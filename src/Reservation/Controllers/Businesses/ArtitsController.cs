namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class ArtistsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateArtistDTO model,
        CancellationToken token)
    {
        var request = CreateArtistCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPost("Points")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] AddArtistPointDTO model,
        CancellationToken token)
    {
        var request = AddArtistPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPost("{artistId:guid}/Services/{serviceId:guid}")]
    public async Task<IActionResult> Post(Guid artistId, Guid serviceId,
        CancellationToken token)
    {
        await _sender.Send(new AddServiceCommandRequest(artistId, serviceId), token);
        return Ok();
    }

    [HttpGet("{ArtistId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] GetArtistQueryRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet("{ArtistId:guid}/Services")]
    [AllowAnonymous]
    public async Task<IActionResult> GetArtistService([FromRoute] GetArtistServicesQueryRequest request,
        CancellationToken token)
    {
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("Businesses/{BusinessId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetArtistByBusinessId([FromRoute] GetArtistByBusinessIdQueryRequest request,
        CancellationToken token)
    {
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateArtistDTO model,
        CancellationToken token)
    {
        var request = UpdateArtistCommandRequest.Create(id, User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveArtistCommandRequest(id, User.UserId()), token);
        return Ok();
    }
}