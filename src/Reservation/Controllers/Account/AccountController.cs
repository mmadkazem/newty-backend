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
    [Authorize(Roles = Role.BusinessUser, AuthenticationSchemes = AuthScheme.TempScheme)]
    [ProducesResponseType(typeof(LoginQueryResponse), 200)]
    public async Task<IActionResult> Login([FromQuery] string code,
        CancellationToken token)
    {
        var request = new LoginQueryRequest(code, User.UserPhoneNumber(), User.Roles());

        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = AuthScheme.RefreshTokenScheme)]
    [ProducesResponseType(typeof(JwtTokensData), 200)]
    public async Task<IActionResult> LoginByRefreshToken(CancellationToken token)
    {
        var request = new LoginByRefreshTokenQueryRequest(User.UserId(), User.Roles());
        var result = await _sender.Send(request, token);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Role.User, AuthenticationSchemes = AuthScheme.InvalidScheme)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO model,
        CancellationToken token)
    {
        await _sender.Send(new UpdateUserCommandRequest(User.UserId(), model.PhoneNumber, model.FullName, model.City), token);
        return Ok(new { Message = AccountSuccessMessage.UserUpdated });
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = AuthScheme.InvalidScheme)]
    public async Task<IActionResult> Logout(CancellationToken token)
    {
        await _sender.Send(new LogoutQueryRequest(User.UserId()), token);
        return Ok(new { Message = AccountSuccessMessage.loggedOut });
    }

    [HttpGet("/api/Account/Admin/Login")]
    [Authorize(Roles = Role.Admin, AuthenticationSchemes = AuthScheme.TempScheme)]
    [ProducesResponseType(typeof(AdminLoginQueryResponse), 200)]
    public async Task<IActionResult> AdminLogin([FromQuery] string code,
        CancellationToken token)
    {
        var result = await _sender.Send(new AdminLoginQueryRequest(User.UserPhoneNumber(), code), token);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Role.User, AuthenticationSchemes = AuthScheme.InvalidScheme)]
    [ProducesResponseType(typeof(GetUserInfoQueryResponse), 200)]
    public async Task<IActionResult> GetInformation(CancellationToken token)
    {
        var result = await _sender.Send(new GetUserInfoQueryRequest(User.UserId()), token);
        return Ok(result);
    }
}