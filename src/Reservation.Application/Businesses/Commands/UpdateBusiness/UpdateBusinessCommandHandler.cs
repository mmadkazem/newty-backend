namespace Reservation.Application.Businesses.Commands.UpdateBusiness;

public sealed class UpdateBusinessCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateBusinessCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.Id, cancellationToken)
            ?? throw new BusinessNotFoundException();

        var city = await _uow.Cities.FindAsyncByName(request.City, cancellationToken)
            ?? throw new CityNotFoundException();

        business.Name = request.Name;
        business.CoverImagePath = request.CoverImagePath;
        business.Description = request.Description;
        business.Address = request.Address;
        business.City = city;
        business.ParvaneKasbImagePath = request.ParvaneKasbImagePath;
        business.ModifiedOn = DateTime.Now;

        business.Holidays.Clear();
        foreach (var holiday in request.Holidays)
        {
            business.Holidays.Add(holiday);
        }
        business.StartHoursOfWor = new(request.StartHoursOfWor.Hour, request.StartHoursOfWor.Minute, 0);
        business.EndHoursOfWor = new(request.EndHoursOfWor.Hour, request.EndHoursOfWor.Minute, 0);
        business.State = BusinessState.Waiting;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}


