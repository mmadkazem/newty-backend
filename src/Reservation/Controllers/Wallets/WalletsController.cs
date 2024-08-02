namespace Reservation.Controllers.Wallets;


[ApiController]
[Route("api/[controller]")]
public sealed class WalletsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("Businesses")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> PostBusiness(CancellationToken token)
    {
        await _sender.Send(new CreateBusinessWalletCommandRequest(User.UserId()), token);
        return Ok();
    }

    [HttpPost("Users")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> PostUsers(CancellationToken token)
    {
        await _sender.Send(new CreateUserWalletCommandRequest(User.UserId()), token);
        return Ok();
    }

    [HttpPut("Users/Found")]
    [EnableCors("FinancePolicy")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> PutFoundUsers(FoundUserWalletCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("Businesses/Found")]
    [EnableCors("FinancePolicy")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> PutFoundBusiness(FoundBusinessWalletCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("Businesses/Withdraw")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> PutWithdrawBusiness(decimal amount,
        CancellationToken token)
    {
        var request = WithdrawBusinessWalletCommandRequest.Create(User.UserId(), amount);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpPut("Users/Withdraw")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> PutWithdrawUsers(decimal amount,
        CancellationToken token)
    {
        var request = WithdrawUserWalletCommandRequest.Create(User.UserId(), amount);
        await _sender.Send(request, token);
        return Ok();
    }

    [HttpGet("Users")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> GetUserWallet(CancellationToken token)
    {
        var result = await _sender.Send(new GetUserWalletQueryRequest(User.UserId()), token);
        return Ok(result);
    }

    [HttpGet("Businesses")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> GetBusinessWallet(CancellationToken token)
    {
        var result = await _sender.Send(new GetBusinessWalletQueryRequest(User.UserId()), token);
        return Ok(result);
    }

    [HttpGet("Users/Transactions/Page/{page:int}")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserScheme)]
    public async Task<IActionResult> GetUserTransactions(int page,
        CancellationToken token)
    {
        var request = GetUserTransactionsQueryRequest.Create(User.UserId(), page);
        var results = await _sender.Send(request, token);
        return Ok(results);
    }

    [HttpGet("Businesses/Transactions/Page/{page:int}")]
    [Authorize(AuthenticationSchemes = AuthScheme.BusinessScheme)]
    public async Task<IActionResult> GetBusinessesTransactions(int page,
        CancellationToken token)
    {
        var request = GetBusinessTransactionsQueryRequest.Create(User.UserId(), page);
        var results = await _sender.Send(request, token);
        return Ok(results);
    }
}