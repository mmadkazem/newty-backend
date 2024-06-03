namespace Reservation.Application.Cities.Queries.GetCities;

public sealed class GetCitiesQueryHandler(IUnitOfWork uow) : IRequestHandler<GetCitiesQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;
    public async Task<IEnumerable<IResponse>>  Handle(GetCitiesQueryRequest request, CancellationToken cancellationToken)
    {
        var cities = await _uow.Cities.GetAll(cancellationToken);
        if (!cities.Any())
        {
            throw new CityNotFoundException();
        }

        return cities;
    }
}