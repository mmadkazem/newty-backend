namespace Reservation.Controllers.Images;


[ApiController]
[Route("api/[controller]")]
public sealed class ImagesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] UploadImageCommandRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpDelete("{ObjectKey}")]
    public async Task<IActionResult> Remove([FromRoute] RemoveImageCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{ObjectKey}")]
    public async Task<IActionResult> GetUrl([FromRoute] GetImageUrlQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
}