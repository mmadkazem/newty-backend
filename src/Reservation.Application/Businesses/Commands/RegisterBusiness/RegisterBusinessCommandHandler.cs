namespace Reservation.Application.Businesses.Commands.RegisterBusiness;


public sealed class RegisterBusinessCommandHandler(IUnitOfWork uow, ICacheProvider cache)
    : IRequestHandler<RegisterBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICacheProvider _cache = cache;

    public async Task Handle(RegisterBusinessCommandRequest request, CancellationToken cancellationToken)
    {
        var city = await _uow.Cities.FindAsyncByName(request.City, cancellationToken);
        BusinessCacheVM business = new(city.Name, request.PhoneNumber);

        await _cache.SetAsync(nameof(Business) + request.PhoneNumber, business);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}