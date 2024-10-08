namespace Reservation.Controllers.Images;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public sealed class ImagesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] UploadImageDTO model,
        CancellationToken token)
    {
        var request = UploadImageCommandRequest.Create(model, User.UserId());
        var result = await _sender.Send(request, token);
        return Ok(new { Key = result, Message = ImageSuccessMessage.Uploaded });
    }

    [HttpDelete("{objectKey}")]
    public async Task<IActionResult> Remove(string objectKey,
        CancellationToken token)
    {
        var request = RemoveImageCommandRequest.Create(objectKey, User.UserId());
        await _sender.Send(request, token);
        return Ok(new { Message = ImageSuccessMessage.Removed });
    }

    [HttpGet("{objectKey}"), AllowAnonymous]
    public async Task<IActionResult> GetUrl(string objectKey,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetImageUrlQueryRequest(objectKey), token);
        return Ok(result);
    }
}