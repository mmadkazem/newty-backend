namespace Reservation.Application.Finances.BusinessRequestPays.Commands.CreateBusinessRequestPay;

public sealed record CreateBusinessRequestPayCommandRequest(Guid BusinessId, int Amount) : IRequest<string>;
