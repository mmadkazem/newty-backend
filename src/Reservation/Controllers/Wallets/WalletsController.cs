namespace Reservation.Controllers.Wallets;


[ApiController]
[Route("[controller]")]
public sealed class UserWalletsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("Businesses")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> PostBusiness()
    {
        await _sender.Send(new CreateBusinessWalletCommandRequest(User.UserId()));
        return Ok();
    }

    [HttpPost("Users")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> PostUsers()
    {
        await _sender.Send(new CreateUserWalletCommandRequest(User.UserId()));
        return Ok();
    }

    [HttpPut("Users/Found")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> PutUsers(decimal credit)
    {
        var request = FoundUserWalletCommandRequest.Create(User.UserId(), credit);
        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("Businesses/Found")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> PutBusiness(decimal credit)
    {
        var request = FoundBusinessWalletCommandRequest.Create(User.UserId(), credit);
        await _sender.Send(request);
        return Ok();
    }

    [HttpGet("Users")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> GetUserWallet()
    {
        var result = await _sender.Send(new GetUserWalletQueryRequest(User.UserId()));
        return Ok(result);
    }

    [HttpGet("Businesses")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> GetBusinessWallet()
    {
        var result = await _sender.Send(new GetBusinessWalletQueryRequest(User.UserId()));
        return Ok(result);
    }

    [HttpGet("Users/Transactions/Page/{page:int}")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> GetUserTransactions(int page)
    {
        var request = GetUserTransactionsQueryRequest.Create(User.UserId(), page);
        var results = await _sender.Send(request);
        return Ok(results);
    }

    [HttpGet("Businesses/Transactions/Page/{page:int}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> GetBusinessesTransactions(int page)
    {
        var request = GetBusinessTransactionsQueryRequest.Create(User.UserId(), page);
        var results = await _sender.Send(request);
        return Ok(results);
    }
}