using Npgsql.Internal;

namespace Reservation.Controllers.Wallets;


[ApiController]
[Route("api/[controller]")]
public sealed class WalletsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("Businesses")]
    [Authorize(Role.Business)]
    public async Task<IActionResult> PostBusiness(CancellationToken token)
    {
        await _sender.Send(new CreateBusinessWalletCommandRequest(User.UserId()), token);
        return Ok(new { Message = WalletSuccessMessage.Created });
    }

    [HttpPost("Users")]
    [Authorize(Roles = Role.User)]
    public async Task<IActionResult> PostUsers(CancellationToken token)
    {
        await _sender.Send(new CreateUserWalletCommandRequest(User.UserId()), token);
        return Ok(new { Message = WalletSuccessMessage.Created });
    }

    [HttpPut("Users/Found")]
    [Authorize(Role.User)]
    public async Task<IActionResult> PutFoundUsers(FoundUserWalletCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok(new { Message = WalletSuccessMessage.Founded });
    }

    [HttpPut("Businesses/Found")]
    [Authorize(Role.Business)]
    public async Task<IActionResult> PutFoundBusiness(FoundBusinessWalletCommandRequest request,
        CancellationToken token)
    {
        await _sender.Send(request, token);
        return Ok(new { Message = WalletSuccessMessage.Founded });
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

    [HttpPut("Users/Withdraw")]
    [Authorize(Role.User)]
    public async Task<IActionResult> PutWithdrawUsers(decimal amount,
        CancellationToken token)
    {
        var request = WithdrawUserWalletCommandRequest.Create(User.UserId(), amount);
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