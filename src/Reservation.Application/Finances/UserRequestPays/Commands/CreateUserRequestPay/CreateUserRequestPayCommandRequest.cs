namespace Reservation.Application.Finances.UserRequestPays.Commands.CreateUserRequestPay;

public record CreateUserRequestPayCommandRequest(Guid UserId, int Amount) : IRequest<string>
{
    public static CreateUserRequestPayCommandRequest Create(Guid userId, int amount)
        => new(userId, amount);
}
