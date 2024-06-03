using Reservation.Application.Cities.Commands.CreateCity;
using Reservation.Application.Cities.Commands.UpdateCity;
using Reservation.Application.Cities.Queries.GetCities;

namespace Reservation.Controllers.Cities;


[ApiController]
[Route("api/[controller]")]
public class CitiesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCityCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateCityCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var results =  await _sender.Send(new GetCitiesQueryRequest());
        return Ok(results);
    }
}