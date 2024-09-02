namespace Reservation.Application.Businesses.Commands.ValidateBusiness;

public sealed class ValidateBusinessCommandHandler(IUnitOfWork uow) : IRequestHandler<ValidateBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(ValidateBusinessCommandRequest request, CancellationToken cancellationToken)
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
        business.State = BusinessState.Waiting;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}


