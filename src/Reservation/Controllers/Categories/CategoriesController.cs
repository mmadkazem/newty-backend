namespace Reservation.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Admin)]
public sealed class CategoriesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post(Guid? ParentId, [FromBody] CreateCategoryDTO model,
        CancellationToken token)
    {
        var request = CreateCategoryCommandRequest.Create(ParentId, model);
        await _sender.Send(request, token);
        return Ok(new { Message = CategorySuccessMessage.Created });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateCategoryDTO model,
        CancellationToken token)
    {
        var request = UpdateCategoryCommandRequest.Create(id, model);
        await _sender.Send(request, token);
        return Ok(new { Message = CategorySuccessMessage.Updated });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveCategoryCommandRequest(id), token);
        return Ok(new { Message = CategorySuccessMessage.Removed });
    }

    [HttpGet("{id:guid}/SubCategory")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSubCategory(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetSubCategoriesByCategoryIdQueryRequest(id), token);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetCategoryQueryRequest(id), token);
        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var results = await _sender.Send(new GetCategoriesQueryRequest(), token);
        return Ok(results);
    }

    [HttpGet("Main")]
    [AllowAnonymous]
    public async Task<IActionResult> GetMainCategory(CancellationToken token)
    {
        var results = await _sender.Send(new GetMainCategoryQueryRequest(), token);
        return Ok(results);
    }

    [HttpGet("{categoryId:guid}/Businesses/Page/{page:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid categoryId, int page,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetCategoryBusinessesQueryRequest(categoryId, page), token);
        return Ok(result);
    }

    [HttpGet("{key}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(string key,
        CancellationToken token)
    {
        var result = await _sender.Send(new SearchCategoryQueryRequest(key), token);
        return Ok(result);
    }

}