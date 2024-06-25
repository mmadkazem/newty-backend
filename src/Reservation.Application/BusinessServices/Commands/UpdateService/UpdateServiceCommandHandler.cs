namespace Reservation.Application.BusinessServices.Commands.UpdateService;

public sealed class UpdateServiceCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateServiceCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
    {
        Service service = await _uow.Services.FindAsync(request.Id, cancellationToken)
            ?? throw new ServiceNotFoundException();

        if (service.Name != request.Name && !await _uow.Services.AnyAsync(request.Name, cancellationToken))
        {
            throw new ServiceAlreadyExistException();
        }
        service.Name = request.Name;
        service.Price = request.Price;
        service.Time = new TimeOnly(request.Time.Hour, request.Time.Minute);
        service.Active = request.Active;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}