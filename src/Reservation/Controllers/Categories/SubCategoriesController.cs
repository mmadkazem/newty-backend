namespace Reservation.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
public sealed class SubCategoriesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    // [Authorize("")]
    public async Task<IActionResult> Post([FromBody] CreateSubCategoryCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpPost("Points")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] AddSubCategoryPointDTO model)
    {
        var request = AddSubCategoryPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut]
    // [Authorize("")]

    public async Task<IActionResult> Put([FromBody] UpdateSubCategoryCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{Page:int}")]
    public async Task<IActionResult> Get([FromRoute] GetSubCategoriesQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get([FromRoute] GetSubCategoryByIdQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTop3()
    {
        var results = await _sender.Send(new GetTop3SubCategoryQueryRequest());
        return Ok(results);
    }
}