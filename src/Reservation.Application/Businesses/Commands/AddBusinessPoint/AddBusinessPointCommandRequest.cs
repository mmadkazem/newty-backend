namespace Reservation.Application.Businesses.Commands.AddBusinessPoint;


public record AddBusinessPointCommandRequest(Guid UserId, Guid BusinessId, int Rate) : IRequest
{
    public static AddBusinessPointCommandRequest Create(Guid userId, AddBusinessPointDTO model)
        => new(userId, model.BusinessId, model.Rate);
}

public record AddBusinessPointDTO(Guid BusinessId, int Rate);
