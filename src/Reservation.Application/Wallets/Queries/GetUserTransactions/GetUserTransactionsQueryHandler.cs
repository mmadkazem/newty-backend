namespace Reservation.Application.Wallets.Queries.GetUserTransactions;

public sealed class GetUserTransactionsQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetUserTransactionsQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetUserTransactionsQueryRequest request, CancellationToken cancellationToken)
    {
        var walletId = await _uow.Wallets.FindAsyncUserWalletId(request.UserId, cancellationToken);
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