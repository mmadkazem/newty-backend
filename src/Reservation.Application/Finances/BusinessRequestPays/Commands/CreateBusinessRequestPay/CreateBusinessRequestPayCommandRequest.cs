namespace Reservation.Application.Finances.BusinessRequestPays.Commands.CreateBusinessRequestPay;

public record CreateBusinessRequestPayCommandRequest(Guid BusinessId, int Amount) : IRequest
{
    public static CreateBusinessRequestPayCommandRequest Create(Guid businessId, int amount)
        => new(businessId, amount);
}
