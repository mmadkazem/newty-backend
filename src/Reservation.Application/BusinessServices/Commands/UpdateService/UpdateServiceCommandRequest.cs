namespace Reservation.Application.BusinessServices.Commands.UpdateService;


public record UpdateServiceCommandRequest(Guid Id,Guid BusinessId, string Name, int Price, Time Time, bool Active) : IRequest
{
    public static UpdateServiceCommandRequest Create(Guid id, Guid businessId, UpdateServiceDTO model)
        => new(id, businessId, model.Name, model.Price, model.Time, model.Active);
}

public record UpdateServiceDTO(string Name, int Price, Time Time, bool Active);