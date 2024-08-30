namespace Reservation.Application.Businesses.Commands.UpdateBusiness;

public sealed record UpdateBusinessCommandRequest
(
    Guid Id, string Name, string CoverImagePath, string CardNumber, bool IsClose,
    string ParvaneKasbImagePath, string Description, string Address, string City,
    IEnumerable<DayOfWeek> Holidays, Time StartHoursOfWor, Time EndHoursOfWor
) : IRequest
{
    public static UpdateBusinessCommandRequest Create(Guid Id, UpdateBusinessDTO model)
        => new(Id, model.Name, model.CoverImagePath, model.CardNumber, model.IsClose,
            model.ParvaneKasbImagePath, model.Description, model.Address, model.City,
            model.Holidays, model.StartHoursOfWork, model.EndHoursOfWork);
}

public readonly record struct UpdateBusinessDTO
(
    string Name, string CoverImagePath, string CardNumber, bool IsClose,
    string ParvaneKasbImagePath, string Description, string Address, string City,
    IEnumerable<DayOfWeek> Holidays, Time StartHoursOfWork, Time EndHoursOfWork
);