namespace Reservation.Application.Businesses.Commands.RegisterBusiness;


public sealed class RegisterBusinessCommandHandler(IUnitOfWork uow)
    : IRequestHandler<RegisterBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RegisterBusinessCommandRequest request, CancellationToken cancellationToken)
    {
        var city = await _uow.Cities.FindAsyncByName(request.City, cancellationToken);
        Business business = new()
        {
            PhoneNumber = request.PhoneNumber,
            City = city
        };

        _uow.Businesses.Add(business);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}