namespace Reservation.Application.SmsPlans.Commands.RemoveSmsPlan;


public sealed record RemoveSmsPlanCommandRequest(Guid Id) : IRequest;
