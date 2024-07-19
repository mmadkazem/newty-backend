namespace Reservation.Application.SmsPlans.Commands.RemoveSmsPlan;

public sealed class RemoveSmsPlanCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveSmsPlanCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemoveSmsPlanCommandRequest request, CancellationToken cancellationToken)
    {
        var smsPlan = await _uow.SmsPlans.FindAsync(request.Id, cancellationToken)
            ?? throw new SmsPlanNotFoundException();

        _uow.SmsPlans.Remove(smsPlan);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}