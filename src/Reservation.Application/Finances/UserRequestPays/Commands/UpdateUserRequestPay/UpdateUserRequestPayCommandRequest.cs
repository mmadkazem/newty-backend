namespace Reservation.Application.Finances.UserRequestPays.Commands.UpdateUserRequestPay;


public record UpdateUserRequestPayCommandRequest(Guid Id, Guid UserId, bool IsPay, string Authorizy, int RefId) : IRequest
{
    public static UpdateUserRequestPayCommandRequest Create(Guid id, Guid userId, UpdateUserRequestPayDTO model)
        => new(id, userId, model.IsPay, model.Authorizy, model.RefId);
}

public record UpdateUserRequestPayDTO(bool IsPay, string Authorizy, int RefId);


