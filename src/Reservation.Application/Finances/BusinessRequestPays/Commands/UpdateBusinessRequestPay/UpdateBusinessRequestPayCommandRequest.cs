namespace Reservation.Application.Finances.BusinessRequestPays.Commands.UpdateBusinessRequestPay;


public record UpdateBusinessRequestPayCommandRequest(Guid Id, Guid BusinessId, string Authorizy, int RefId, bool IsPay) : IRequest
{
    public static UpdateBusinessRequestPayCommandRequest Create(Guid id, Guid businessId, UpdateBusinessRequestPayDTO model)
        => new(id, businessId, model.Authorizy, model.RefId, model.IsPay);
}
public record UpdateBusinessRequestPayDTO(string Authorizy, int RefId, bool IsPay);