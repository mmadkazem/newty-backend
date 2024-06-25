namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTime;

public sealed class UpdateStateReserveTimeReceiptCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateStateReserveTimeReceiptCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateStateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        var reserveTime = await _uow.ReserveTimes.FindAsync(request.Id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();

        reserveTime.State = request.State;
        reserveTime.Finished = request.Finished;
        reserveTime.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}