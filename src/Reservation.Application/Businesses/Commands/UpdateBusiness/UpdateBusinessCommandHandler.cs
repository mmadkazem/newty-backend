namespace Reservation.Application.Businesses.Commands.UpdateBusiness;

public sealed class UpdateBusinessCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateBusinessCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.Id, cancellationToken)
            ?? throw new BusinessNotFoundException();

        if (business.PhoneNumber != request.PhoneNumber && !await _uow.Users.AnyAsync(request.PhoneNumber, cancellationToken))
        {
            throw new PhonNumberAlreadyExistException();
        }

        var city = await _uow.Cities.FindAsyncByName(request.City, cancellationToken)
            ?? throw new CityNotFoundException();

        business.PhoneNumber = request.PhoneNumber;
        business.Name = request.Name;
        business.Description = request.Description;
        business.Address = request.Address;
        business.City = city;
        business.ParvaneKasbImagePath = request.ParvaneKasbImagePath;
        business.ModifiedOn = DateTime.Now;
        foreach (var holiday in request.Holidays)
        {
            business.Holidays.Add(holiday);
        }
        business.StartHoursOfWor = new(request.StartHoursOfWor.Hour, request.StartHoursOfWor.Minute, 0);
        business.EndHoursOfWor = new(request.StartHoursOfWor.Hour, request.StartHoursOfWor.Minute, 0);

        await _uow.SaveChangeAsync(cancellationToken);
    }
}


