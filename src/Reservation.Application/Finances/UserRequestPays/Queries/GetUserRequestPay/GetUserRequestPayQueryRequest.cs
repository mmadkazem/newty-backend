namespace Reservation.Application.Finances.UserRequestPays.Queries.GetUserRequestPay;


public record GetUserRequestPayQueryRequest(Guid Id) : IRequest<IResponse>;

public record GetUserRequestPayQueryResponse
(
    Guid Id,
    DateTime PayDate,
    bool IsPay,
    int Amount,
    string Authorizy,
    int RefId
) : IResponse;
