namespace Reservation.Application.Finances.BusinessRequestWithdraws.Queries.GetBusinessRequestWithdraw;


public sealed record GetBusinessRequestWithdrawQueryRequest(int Page, int Size)
    : IRequest<Response>;


public sealed record GetBusinessRequestWithdrawQueryResponse
(
    Guid Id,
    Guid BusinessesId,
    string CardNumber,
    decimal Amount
): IResponse;