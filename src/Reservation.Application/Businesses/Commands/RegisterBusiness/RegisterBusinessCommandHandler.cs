namespace Reservation.Application.Businesses.Commands.RegisterBusiness;


public sealed class RegisterBusinessCommandHandler(IUnitOfWork uow, ICacheProvider cache)
    : IRequestHandler<RegisterBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICacheProvider _cache = cache;

    public async Task Handle(RegisterBusinessCommandRequest request, CancellationToken cancellationToken)
        => await _cache.SetAsync<BusinessRegisterCacheVM>(BusinessRegisterCacheVM.ToKey(request.PhoneNumber), new(request.City, request.PhoneNumber, request.Name), TimeSpan.FromHours(1), cancellationToken);
}