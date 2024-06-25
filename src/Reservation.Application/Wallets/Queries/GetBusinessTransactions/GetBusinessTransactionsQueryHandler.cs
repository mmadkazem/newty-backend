namespace Reservation.Application.Wallets.Queries.GetBusinessTransactions;

public sealed class GetBusinessTransactionsQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetBusinessTransactionsQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetBusinessTransactionsQueryRequest request, CancellationToken cancellationToken)
    {
        var walletId = await _uow.Wallets.FindAsyncBusinessWalletId(request.BusinessId, cancellationToken);
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