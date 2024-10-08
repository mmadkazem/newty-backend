
namespace Reservation.Application.Cities.Commands.CreateCity;

public sealed class CreateCityCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateCityCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateCityCommandRequest request, CancellationToken cancellationToken)
    {
        City city = new()
        {
            FaName = request.Name,
            Alternatives = request.Alternatives,
            Key = request.Key,
        };

        _uow.Cities.Add(city);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}