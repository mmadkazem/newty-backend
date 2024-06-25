namespace Reservation.Application.Wallets.Queries.GetUserTransactions;


public record GetUserTransactionsQueryRequest(Guid UserId, int Page) : IRequest<IEnumerable<IResponse>>
{
    public static GetUserTransactionsQueryRequest Create(Guid userId, int page)
        => new(userId, page);
}

public record GetUserTransactionsQueryResponse
(
    Guid Id,
    DateTime CreatedOn,
    decimal Amount,
    Guid ReserveTimeId
) : IResponse;
