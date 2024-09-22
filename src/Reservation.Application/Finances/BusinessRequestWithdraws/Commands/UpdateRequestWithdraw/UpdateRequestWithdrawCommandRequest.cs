namespace Reservation.Application.Finances.BusinessRequestWithdraws.Commands.UpdateRequestWithdraw;


public sealed record UpdateRequestWithdrawCommandRequest(Guid Id, Guid BusinessId)
    :  IRequest;


public sealed class UpdateRequestWithdrawCommandHandler(IUnitOfWork uow)
    : IRequestHandler<UpdateRequestWithdrawCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateRequestWithdrawCommandRequest request, CancellationToken token)
    {
        var requestWithdraw = await _uow.BusinessRequestWithdraws.FindAsync(request.Id, token)
            ?? throw new RequestWithdrawNotFoundException();

        var wallet = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessId, token)
            ?? throw new WalletNotFoundException();

        wallet.BlockCreditInWithdraw -= requestWithdraw.Amount;
        requestWithdraw.IsWithdraw = true;
        wallet.Transactions.Add(new() { Amount = requestWithdraw.Amount, Type = TransactionType.Withdraw});


        await _uow.SaveChangeAsync(token);
    }
}