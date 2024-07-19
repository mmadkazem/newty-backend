namespace Reservation.Application.Finances.UserRequestPays.Commands.RemoveUserRequestPay;

public sealed record RemoveUserRequestPayCommandRequest(Guid Id, Guid UserId) : IRequest;
