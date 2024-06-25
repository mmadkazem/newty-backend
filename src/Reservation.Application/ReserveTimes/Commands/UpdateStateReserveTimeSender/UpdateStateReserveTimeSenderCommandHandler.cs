
namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTimeSender;

public sealed class UpdateStateReserveTimeSenderCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateStateReserveTimeSenderCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateStateReserveTimeSenderCommandRequest request, CancellationToken cancellationToken)
    {
        var reserveTime = await _uow.ReserveTimes.FindAsyncReserveTimeSender(request.Id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();

        reserveTime.State = request.State;
        reserveTime.Finished = request.Finished;
        reserveTime.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}