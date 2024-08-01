namespace Reservation.Application.Account.Queries.AdminLogin;


public record AdminLoginQueryRequest(string PhoneNumber, string Code) : IRequest<AdminLoginQueryResponse>;
