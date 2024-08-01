namespace Reservation.Controllers.Account;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class AccountController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> LoginInit([FromQuery] LoginInitQueryRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Login([FromQuery] string code,
        CancellationToken token)
    {
        var request = new LoginQueryRequest(code, User.UserPhoneNumber(), User.Roles());

        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = AuthScheme.RefreshTokenScheme)]
    public async Task<IActionResult> LoginByRefreshToken(CancellationToken token)
    {
        var request = new LoginByRefreshTokenQueryRequest(User.UserId(), User.Roles());
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO model,
        CancellationToken token)
    {
        var request = new UpdateUserCommandRequest(User.UserId(), model.FullName, model.PhoneNumber, model.City);
        await _sender.Send(request, token);
        return Ok(new { Message = AccountSuccess.UserUpdated });
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> Logout(CancellationToken token)
    {
        await _sender.Send(new LogoutQueryRequest(User.UserId()), token);
        return Ok(new { Message = AccountSuccess.loggedOut });
    }

    [HttpGet("/api/Account/Admin/Login")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> AdminLogin([FromQuery] string code,
        CancellationToken token)
    {
        var result = await _sender.Send(new AdminLoginQueryRequest(User.UserPhoneNumber(), code), token);
        return Ok(result);
    }
}