namespace Reservation.Application.Businesses.Commands.UpdateIsCancelReserveTime;


public sealed record UpdateIsCancelReserveTimeCommandRequest(Guid BusinessId, bool IsCancelReserveTime) : IRequest;


public sealed class UpdateIsCancelReserveTimeCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateIsCancelReserveTimeCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateIsCancelReserveTimeCommandRequest request, CancellationToken cancellationToken)
    {
        var businesses = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        businesses.IsCancelReserveTime = request.IsCancelReserveTime;
        businesses.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}
