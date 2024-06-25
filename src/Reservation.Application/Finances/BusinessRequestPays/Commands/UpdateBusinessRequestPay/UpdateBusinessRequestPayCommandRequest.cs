namespace Reservation.Application.Finances.BusinessRequestPays.Commands.UpdateBusinessRequestPay;


public record UpdateBusinessRequestPayCommandRequest(Guid Id, string Authorizy, int RefId, bool IsPay) : IRequest
{
    public static UpdateBusinessRequestPayCommandRequest Create(Guid id, UpdateBusinessRequestPayDTO model)
        => new(id, model.Authorizy, model.RefId, model.IsPay);
}
public record UpdateBusinessRequestPayDTO(string Authorizy, int RefId, bool IsPay);