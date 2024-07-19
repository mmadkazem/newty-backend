namespace Reservation.Application.BusinessServices.Commands.RemoveService;

public sealed class RemoveServiceCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveServiceCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemoveServiceCommandRequest request, CancellationToken cancellationToken)
    {
        var service = await _uow.Services.FindAsync(request.Id, cancellationToken)
            ?? throw new ServiceNotFoundException();

        if (service.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToRemoveItem("سرویس");
        }

        _uow.Services.Remove(service);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}