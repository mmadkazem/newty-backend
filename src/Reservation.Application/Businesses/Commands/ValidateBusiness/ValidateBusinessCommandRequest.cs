namespace Reservation.Application.Businesses.Commands.ValidateBusiness;

public sealed record ValidateBusinessCommandRequest
(
    Guid Id, string Name, string CoverImagePath, string CardNumber,
    string ParvaneKasbImagePath, string Description, string Address, string City
) : IRequest
{
    public static ValidateBusinessCommandRequest Create(Guid Id, ValidateBusinessDTO model)
        => new(Id, model.Name, model.CoverImagePath, model.CardNumber,
            model.ParvaneKasbImagePath, model.Description, model.Address, model.City);
}

public readonly record struct ValidateBusinessDTO
(
    string Name, string CoverImagePath, string CardNumber,
    string ParvaneKasbImagePath, string Description, string Address, string City
);