namespace Reservation.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Admin)]
public sealed class CategoriesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post(int? ParentId, [FromBody] CreateCategoryDTO model,
        CancellationToken token)
    {
        var request = CreateCategoryCommandRequest.Create(ParentId, model);
        await _sender.Send(request, token);
        return Ok(new { Message = CategorySuccessMessage.Created });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, UpdateCategoryDTO model,
        CancellationToken token)
    {
        var request = UpdateCategoryCommandRequest.Create(id, model);
        await _sender.Send(request, token);
        return Ok(new { Message = CategorySuccessMessage.Updated });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remove(int id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveCategoryCommandRequest(id), token);
        return Ok(new { Message = CategorySuccessMessage.Removed });
    }

    [HttpGet("{id:int}/SubCategory")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetSubCategoriesByCategoryIdQueryResponse), 200)]
    public async Task<IActionResult> GetSubCategory(int id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetSubCategoriesByCategoryIdQueryRequest(id), token);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetCategoryQueryResponse), 200)]
    public async Task<IActionResult> Get(int id,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetCategoryQueryRequest(id), token);
        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetCategoriesQueryResponse), 200)]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var results = await _sender.Send(new GetCategoriesQueryRequest(), token);
        return Ok(results);
    }

    [HttpGet("Main")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetMainCategoryQueryResponse), 200)]
    public async Task<IActionResult> GetMainCategory(CancellationToken token)
    {
        var results = await _sender.Send(new GetMainCategoryQueryRequest(), token);
        return Ok(results);
    }

    [HttpGet("{categoryId:int}/Businesses/Page/{page:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetCategoryBusinessesQueryResponse), 200)]
    public async Task<IActionResult> Get(int categoryId, int page,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetCategoryBusinessesQueryRequest(categoryId, page), token);
        return Ok(result);
    }

    [HttpGet("{key}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SearchCategoryQueryResponse), 200)]
    public async Task<IActionResult> Get(string key,
        CancellationToken token)
    {
        var result = await _sender.Send(new SearchCategoryQueryRequest(key), token);
        return Ok(result);
    }

}