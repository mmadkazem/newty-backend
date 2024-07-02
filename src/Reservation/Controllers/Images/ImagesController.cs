namespace Reservation.Controllers.Images;


[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
[Authorize(AuthenticationSchemes = AuthScheme.AdminScheme)]
[Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
public sealed class ImagesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] UploadImageDTO model)
    {
        var request = UploadImageCommandRequest.Create(model, User.UserId());
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpDelete("{objectKey}")]
    public async Task<IActionResult> Remove(string objectKey)
    {
        var request = RemoveImageCommandRequest.Create(objectKey, User.UserId());
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{objectKey}"), AllowAnonymous]
    public async Task<IActionResult> GetUrl([FromRoute] GetImageUrlQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
}