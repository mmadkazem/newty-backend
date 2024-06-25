namespace Reservation.Application.Finances.UserRequestPays.Commands.UpdateUserRequestPay;


public record UpdateUserRequestPayCommandRequest(Guid Id, bool IsPay, string Authorizy, int RefId) : IRequest
{
    public static UpdateUserRequestPayCommandRequest Create(Guid id, UpdateUserRequestPayDTO model)
        => new(id, model.IsPay, model.Authorizy, model.RefId);
}

public record UpdateUserRequestPayDTO(bool IsPay, string Authorizy, int RefId);


