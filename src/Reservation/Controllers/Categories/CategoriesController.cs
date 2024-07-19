using Npgsql.Internal;
using Reservation.Application.Categories.Queries.GetCategoryBusinesses;
using Reservation.Application.Categories.Queries.SearchCategory;

namespace Reservation.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = AuthScheme.AdminScheme)]
public sealed class CategoriesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post(Guid? ParentId, CreateCategoryDTO model,
        CancellationToken token)
    {
        var request = CreateCategoryCommandRequest.Create(ParentId, model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPost("Points")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Post([FromBody] AddCategoryPointDTO model,
        CancellationToken token)
    {
        var request = AddCategoryPointCommandRequest.Create(User.UserId(), model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid Id, UpdateCategoryDTO model,
        CancellationToken token)
    {
        var request = UpdateCategoryCommandRequest.Create(Id, model);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> Remove(Guid Id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveCategoryCommandRequest(Id), token);
        return Ok();
    }

    [HttpGet("{Id:guid}/SubCategory")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] GetSubCategoriesByCategoryIdQueryRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet("{Id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] GetCategoryQueryRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet("{page:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int page,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetCategoriesQueryRequest(page), token);
        return Ok(results);
    }

    [HttpGet("Top3")]
    [AllowAnonymous]
    public async Task<IActionResult> GetTop3([FromBody] GetTop3SubCategoryQueryRequest request,
        CancellationToken token)
    {
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("{categoryId:guid}/Page/{page:int}/Businesses")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int page, Guid categoryId,
        CancellationToken token)
    {
        var result = await _sender.Send(new GetCategoryBusinessesQueryRequest(categoryId, page), token);
        return Ok(result);
    }

    [HttpGet("{key}/Page/{page:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int page, string key,
        CancellationToken token)
    {
        var result = await _sender.Send(new SearchCategoryQueryRequest(key, page), token);
        return Ok(result);
    }

}