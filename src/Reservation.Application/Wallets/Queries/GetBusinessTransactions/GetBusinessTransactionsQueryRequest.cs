namespace Reservation.Application.Wallets.Queries.GetBusinessTransactions;


public record GetBusinessTransactionsQueryRequest(Guid BusinessId, int Page) : IRequest<IEnumerable<IResponse>>
{
    public static GetBusinessTransactionsQueryRequest Create(Guid businessId, int page)
        => new(businessId, page);
}

public record GetBusinessTransactionsQueryResponse
(
    Guid Id,
    DateTime CreatedOn,
    decimal Amount,
    Guid ReserveTimeId
) : IResponse;
