namespace Reservation.Application.SmsPlans.Commands.UpdateSmsPlan;


public sealed record UpdateSmsPlanCommandRequest
(
    Guid Id, string Name,
    string Description,
    int Count, decimal Price,
    string CoverImagePath, int Discount
) : IRequest
{
    public static UpdateSmsPlanCommandRequest Create(Guid id, UpdateSmsPlanDTO model)
        => new(id, model.Name, model.Description, model.Count,
                model.Price, model.CoverImagePath, model.Discount);
}

public sealed record UpdateSmsPlanDTO
(
    string Name,
    string Description,
    int Count, decimal Price,
    string CoverImagePath, int Discount
);
