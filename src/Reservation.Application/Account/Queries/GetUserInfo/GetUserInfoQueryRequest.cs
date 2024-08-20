namespace Reservation.Application.Account.Queries.GetUserInfo;


public sealed record GetUserInfoQueryRequest(Guid Id) : IRequest<IResponse>;


public sealed record GetUserInfoQueryResponse
(
    Guid Id, string PhoneNumber,
    string FullName, string City
) : IResponse;