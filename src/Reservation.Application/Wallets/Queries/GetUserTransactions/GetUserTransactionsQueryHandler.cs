namespace Reservation.Application.Wallets.Queries.GetUserTransactions;

public sealed class GetUserTransactionsQueryHandler(IUnitOfWork uow) : IRequestHandler<GetUserTransactionsQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetUserTransactionsQueryRequest request, CancellationToken cancellationToken)
    {
        var walletId = await _uow.Wallets.FindAsyncUserWalletId(request.UserId, cancellationToken);
        if (walletId == Guid.Empty)
        {
            throw new UserNotFoundException();
        }

        var responses = await _uow.Wallets.GetTransactions(request.Page, walletId, cancellationToken);
        if (!responses.Any())
        {
            throw new TransactionNotFoundException();
        }

        return responses;
    }
}