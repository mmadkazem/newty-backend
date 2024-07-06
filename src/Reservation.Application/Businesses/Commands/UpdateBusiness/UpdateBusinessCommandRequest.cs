namespace Reservation.Application.Businesses.Commands.UpdateBusiness;

public record UpdateBusinessCommandRequest
(
    Guid Id, string PhoneNumber, string Name,string CoverImagePath,
    string ParvaneKasbImagePath, string Description, string Address, string City,
    IEnumerable<DayOfWeek> Holidays, Time StartHoursOfWor, Time EndHoursOfWor
) : IRequest
{
    public static UpdateBusinessCommandRequest Create(Guid Id, UpdateBusinessDTO model)
        => new(Id, model.PhoneNumber, model.Name, model.CoverImagePath,
            model.ParvaneKasbImagePath, model.Description, model.Address, model.City,
            model.Holidays, model.StartHoursOfWor, model.EndHoursOfWor);
}

public record UpdateBusinessDTO
(
    string PhoneNumber, string Name, bool Active, string CoverImagePath,
    string ParvaneKasbImagePath, string Description, string Address, string City,
    IEnumerable<DayOfWeek> Holidays, Time StartHoursOfWor, Time EndHoursOfWor
);