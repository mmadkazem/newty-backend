namespace Reservation.Application.Finances.BusinessRequestPays.Queries.GetBusinessRequestPays;


public record GetBusinessRequestPaysQueryRequest(int Page, Guid BusinessId) : IRequest<IEnumerable<IResponse>>;

public record GetBusinessRequestPaysQueryResponse
(
    Guid Id,
    DateTime PayDate,
    bool IsPay,
    int Amount
) : IResponse;
