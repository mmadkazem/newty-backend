namespace Reservation.Application.Wallets.Queries.GetBusinessTransactions;


public record GetBusinessTransactionsQueryRequest(Guid BusinessId, int Page, int Size) : IRequest<Response>;
