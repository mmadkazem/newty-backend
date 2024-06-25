namespace Reservation.Application.Wallets.Queries.GetUserWallet;

public record GetUserWalletQueryRequest(Guid UserId) : IRequest<IResponse>;

public record GetUserWalletQueryResponse(Guid Id, decimal Credit) : IResponse;
