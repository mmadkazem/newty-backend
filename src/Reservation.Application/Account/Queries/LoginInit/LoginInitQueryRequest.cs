namespace Reservation.Application.Account.Queries.LoginInit;

public record LoginInitQueryRequest(string PhoneNumber) : IRequest<string>;