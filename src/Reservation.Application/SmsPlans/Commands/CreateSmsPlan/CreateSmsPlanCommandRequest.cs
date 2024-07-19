namespace Reservation.Application.SmsPlans.Commands.CreateSmsPlan;


public sealed record CreateSmsPlanCommandRequest
(
    string Name, string Description,
    int Count, decimal Price,
    string CoverImagePath, int Discount
) : IRequest;