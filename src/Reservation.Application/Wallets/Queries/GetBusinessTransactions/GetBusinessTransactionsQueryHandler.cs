namespace Reservation.Application.Wallets.Queries.GetBusinessTransactions;

public sealed class GetBusinessTransactionsQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetBusinessTransactionsQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetBusinessTransactionsQueryRequest request, CancellationToken cancellationToken)
    {
        var walletId = await _uow.Wallets.FindAsyncBusinessWalletId(request.BusinessId, cancellationToken);
        if (walletId == Guid.Empty)
        {
            throw new UserNotFoundException();
        }

        var responses = await _uow.Wallets.GetTransactions(request.Page, request.Size, walletId, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}