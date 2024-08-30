namespace Reservation.Application.Wallets.Queries.GetUserTransactions;


public record GetUserTransactionsQueryRequest(Guid UserId, int Page, int Size) : IRequest<Response>;
