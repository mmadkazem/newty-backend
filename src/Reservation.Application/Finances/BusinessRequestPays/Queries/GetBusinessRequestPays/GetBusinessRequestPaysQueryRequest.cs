namespace Reservation.Application.Finances.BusinessRequestPays.Queries.GetBusinessRequestPays;


public record GetBusinessRequestPaysQueryRequest(int Page, int Size, Guid BusinessId) : IRequest<Response>;

public record GetBusinessRequestPaysQueryResponse
(
    Guid Id,
    DateTime PayDate,
    bool IsPay,
    int Amount
) : IResponse;
