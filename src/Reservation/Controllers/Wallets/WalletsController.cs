namespace Reservation.Controllers.Wallets;


[ApiController]
[Route("api/[controller]")]
public sealed class WalletsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPut("Users/RequestPay/{requestPayId:guid}")]
    public async Task<IActionResult> PutFoundUsers(Guid requestPayId, string authorizy,
        CancellationToken token)
    {
        var result = await _sender.Send(new FoundUserWalletCommandRequest(requestPayId, authorizy), token);
        return Redirect(result);
    }

    [HttpPut("Businesses/RequestPay/{requestPayId:guid}")]
    public async Task<IActionResult> PutFoundBusiness(Guid requestPayId, string authorizy,
        CancellationToken token)
    {
        var result = await _sender.Send(new FoundBusinessWalletCommandRequest(requestPayId, authorizy), token);
        return Redirect(result);
    }

    [HttpPut("Businesses/Withdraw")]
    [Authorize(Role.Business)]
    public async Task<IActionResult> PutWithdrawBusiness(decimal amount,
        CancellationToken token)
    {
        var request = WithdrawBusinessWalletCommandRequest.Create(User.UserId(), amount);
        await _sender.Send(request, token);
        return Ok(new { Message = WalletSuccessMessage.Withdraw });
    }

    [HttpGet("Users")]
    [Authorize(Role.User)]
    [ProducesResponseType(typeof(GetUserWalletQueryResponse), 200)]
    public async Task<IActionResult> GetUserWallet(CancellationToken token)
    {
        var result = await _sender.Send(new GetUserWalletQueryRequest(User.UserId()), token);
        return Ok(result);
    }

    [HttpGet("Businesses")]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(GetBusinessWalletQueryResponse), 200)]
    public async Task<IActionResult> GetBusinessWallet(CancellationToken token)
    {
        var result = await _sender.Send(new GetBusinessWalletQueryRequest(User.UserId()), token);
        return Ok(result);
    }

    [HttpGet("Users/Transactions/Page/{page:int}/Size/{size:int}")]
    [Authorize(Role.User)]
    [ProducesResponseType(typeof(Response<GetWalletTransactionsQueryResponse>), 200)]
    public async Task<IActionResult> GetUserTransactions(int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetUserTransactionsQueryRequest(User.UserId(), page, size), token);
        return Ok(results);
    }

    [HttpGet("Businesses/Transactions/Page/{page:int}/Size/{size:int}")]
    [Authorize(Role.Business)]
    [ProducesResponseType(typeof(Response<GetWalletTransactionsQueryResponse>), 200)]
    public async Task<IActionResult> GetBusinessesTransactions(int page, int size,
        CancellationToken token)
    {
        var results = await _sender.Send(new GetBusinessTransactionsQueryRequest(User.UserId(), page, size), token);
        return Ok(results);
    }
}