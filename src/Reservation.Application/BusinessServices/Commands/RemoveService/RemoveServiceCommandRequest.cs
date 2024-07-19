namespace Reservation.Application.BusinessServices.Commands.RemoveService;


public sealed record RemoveServiceCommandRequest(Guid Id, Guid BusinessId) : IRequest;
