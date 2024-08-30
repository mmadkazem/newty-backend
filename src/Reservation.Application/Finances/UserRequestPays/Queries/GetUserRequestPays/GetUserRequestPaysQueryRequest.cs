namespace Reservation.Application.Finances.UserRequestPays.Queries.GetUserRequestPays;


public record GetUserRequestPaysQueryRequest(Guid UserId, int Page, int Size) : IRequest<Response>;

public record GetUserRequestPaysQueryResponse
(
    Guid Id,
    DateTime PayDate,
    bool IsPay,
    int Amount
) : IResponse;
