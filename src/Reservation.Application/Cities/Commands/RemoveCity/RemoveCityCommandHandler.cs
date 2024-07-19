namespace Reservation.Application.Cities.Commands.RemoveCity;

public sealed class RemoveCityCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveCityCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemoveCityCommandRequest request, CancellationToken cancellationToken)
    {
        var city = await _uow.Cities.FindAsync(request.Id, cancellationToken)
            ?? throw new CityNotFoundException();

        _uow.Cities.Remove(city);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}