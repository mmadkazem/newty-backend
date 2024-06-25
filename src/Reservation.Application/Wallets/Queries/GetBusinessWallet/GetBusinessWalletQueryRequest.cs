namespace Reservation.Application.Wallets.Queries.GetBusinessWallet;


public record GetBusinessWalletQueryRequest(Guid BusinessId) : IRequest<IResponse>;
public record GetBusinessWalletQueryResponse(Guid Id, decimal Credit) : IResponse;
