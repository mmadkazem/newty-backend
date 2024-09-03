namespace Reservation.Application.BusinessServices.Commands.CreateService;

public sealed class CreateServiceCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateServiceCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateServiceCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        business.IsValidate();

        BusinessService service = new()
        {
            Name = request.Name,
            Price = request.Price,
            Time = new TimeOnly(request.Time.Hour, request.Time.Minute),
            Business = business
        };

        _uow.Services.Add(service);
        await _uow.SaveChangeAsync(cancellationToken);

    }
}