namespace Reservation.Controllers.Cities;


[ApiController]
[Route("api/[controller]")]
[Authorize(Role.Business)]
public sealed class CitiesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCityCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok(new { Message = CitySuccessMessage.Created });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, string name, string state,
        CancellationToken token)
    {
        var request = UpdateCityCommandRequest.Create(id, name, state);
        await _sender.Send(request, token);
        return Ok(new { Message = CitySuccessMessage.Updated });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token)
    {
        await _sender.Send(new RemoveCityCommandRequest(id), token);
        return Ok(new { Message = CitySuccessMessage.Removed });
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var results = await _sender.Send(new GetCitiesQueryRequest(), token);
        return Ok(results);
    }
}