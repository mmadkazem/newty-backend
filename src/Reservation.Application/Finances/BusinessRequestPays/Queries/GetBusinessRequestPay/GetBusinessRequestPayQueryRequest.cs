namespace Reservation.Application.Finances.BusinessRequestPays.Queries.GetBusinessRequestPay;


public record GetBusinessRequestPayQueryRequest(Guid Id) : IRequest<IResponse>;

public record GetBusinessRequestPayQueryResponse
(
    Guid Id,
    DateTime PayDate,
    bool IsPay,
    int Amount,
    string Authorizy,
    int RefId
) : IResponse;
