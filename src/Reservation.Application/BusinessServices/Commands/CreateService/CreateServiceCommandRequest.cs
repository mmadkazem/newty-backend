namespace Reservation.Application.BusinessServices.Commands.CreateService;


public record CreateServiceCommandRequest(string Name, int Price, Time Time, Guid BusinessId)
    : IRequest
{
    public static CreateServiceCommandRequest Create(Guid businessId, CreateServiceDTO model)
        => new(model.Name, model.Price, model.Time, businessId);
}

public record CreateServiceDTO(string Name, int Price, Time Time);
