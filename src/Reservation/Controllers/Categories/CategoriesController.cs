namespace Reservation.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
public sealed class CategoriesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    // [Authorize("")]
    public async Task<IActionResult> Post([FromBody] CreateCategoryCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpPost("Points")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] AddCategoryPointDTO model)
    {
        var request = AddCategoryPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid Id,  UpdateCategoryDTO model)
    {
        var request = UpdateCategoryCommandRequest.Create(Id, model);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("{Id:guid}/SubCategory")]
    public async Task<IActionResult> Get([FromRoute] GetSubCategoriesByCategoryIdQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get([FromRoute] GetCategoryQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpGet("{Page:int}")]
    public async Task<IActionResult> Get([FromRoute] GetCategoriesQueryRequest request)
    {
        var results = await _sender.Send(request);
        return Ok(results);
    }

}