namespace Reservation.Application.Cities.Commands.UpdateCity;

public sealed class UpdateCityCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateCityCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateCityCommandRequest request, CancellationToken cancellationToken)
    {
        var city = await _uow.Cities.FindAsync(request.Id, cancellationToken)
            ?? throw new CityNotFoundException();

        if (city.Name != request.Name && !await _uow.Categories.AnyAsync(request.Name, cancellationToken))
        {
            throw new CityAlreadyExistException();
        }

        city.Name = request.Name;
        city.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}