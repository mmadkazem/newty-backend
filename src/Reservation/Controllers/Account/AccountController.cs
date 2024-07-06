using Reservation.Application.Account.Queries.AdminLogin;
using Reservation.Application.Account.Queries.LogoutUser;

namespace Reservation.Controllers.Account;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class AccountController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> LoginInit([FromQuery] LoginInitQueryRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Login([FromQuery] string code)
    {
        var request = new LoginQueryRequest(code, User.UserPhoneNumber(), User.Roles());

        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = AuthScheme.RefreshTokenScheme)]
    public async Task<IActionResult> LoginByRefreshToken()
    {
        var request = new LoginByRefreshTokenQueryRequest(User.UserId(), User.Roles());
        var result = await _sender.Send(request);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO model)
    {
        var request = new UpdateUserCommandRequest(User.UserId(), model.FullName, model.PhoneNumber, model.City);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Logout()
    {
        await _sender.Send(new LogoutQueryRequest(User.UserId()));
        return Ok();
    }

    [HttpGet("/api/Account/Admin/Login")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> AdminLogin([FromQuery] string code)
    {
        var result = await _sender.Send(new AdminLoginQueryRequest(User.UserPhoneNumber(), code));
        return Ok(result);
    }
}