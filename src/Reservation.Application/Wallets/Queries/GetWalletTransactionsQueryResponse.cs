namespace Reservation.Application.Wallets.Queries.GetUserTransactions;

public record GetWalletTransactionsQueryResponse
(
    Guid Id,
    DateTime CreatedOn,
    decimal Amount,
    TransactionType Type,
    TransactionState State
) : IResponse;
