namespace Reservation.Controllers.Businesses;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class ArtistsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateArtistDTO model)
    {
        var request = CreateArtistCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPost("Points")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] AddArtistPointDTO model)
    {
        var request = AddArtistPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPost("{artistId:guid}/Services/{serviceId:guid}")]
    public async Task<IActionResult> Post(Guid artistId, Guid serviceId)
    {
        await _sender.Send(new AddServiceCommandRequest(artistId, serviceId));
        return Ok();
    }

    [HttpGet("{ArtistId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] GetArtistQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpGet("{ArtistId:guid}/Services")]
    [AllowAnonymous]
    public async Task<IActionResult> GetArtistService([FromRoute] GetArtistServicesQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("Businesses/{BusinessId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetArtistByBusinessId([FromRoute] GetArtistByBusinessIdQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] UpdateArtistDTO model)
    {
        var request = UpdateArtistCommandRequest.Create(Id, model);
        await _sender.Send(request);
        return Ok();
    }
}