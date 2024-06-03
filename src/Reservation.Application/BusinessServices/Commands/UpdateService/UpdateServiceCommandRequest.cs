namespace Reservation.Application.BusinessServices.Commands.UpdateService;


public record UpdateServiceCommandRequest(Guid Id, string Name, int Price, Time Time, bool Active) : IRequest
{
    public static UpdateServiceCommandRequest Create(Guid id, UpdateServiceDTO model)
        => new(id, model.Name, model.Price, model.Time, model.Active);
}

public record UpdateServiceDTO(string Name, int Price, Time Time, bool Active);