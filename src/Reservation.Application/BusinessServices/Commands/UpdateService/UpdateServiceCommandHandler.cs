namespace Reservation.Application.BusinessServices.Commands.UpdateService;

public sealed class UpdateServiceCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateServiceCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
    {
        var service = await _uow.Services.FindAsync(request.Id, cancellationToken)
            ?? throw new ServiceNotFoundException();

        service.Business.IsValidate();

        if (service.Name != request.Name && !await _uow.Services.AnyAsync(request.Name, cancellationToken))
        {
            throw new ServiceAlreadyExistException();
        }

        if (service.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToChangeItemException("خدمات");
        }

        service.Name = request.Name;
        service.Price = request.Price;
        service.Time = new TimeOnly(request.Time.Hour, request.Time.Minute);
        service.Active = request.Active;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}