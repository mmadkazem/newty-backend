namespace Reservation.Application.Finances.BusinessRequestPays.Commands.RemoveBusinessRequest;



public sealed record RemoveBusinessRequestCommandRequest(Guid Id, Guid BusinessId) : IRequest;


public sealed class RemoveBusinessRequestCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveBusinessRequestCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemoveBusinessRequestCommandRequest request, CancellationToken cancellationToken)
    {
        var businessRequestPay = await _uow.BusinessRequestPays.FindAsync(request.Id, cancellationToken)
            ?? throw new BusinessRequestPayNotFoundException();

        if (businessRequestPay.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToRemoveItemException("درخواست پرداخت");
        }

        _uow.BusinessRequestPays.Remove(businessRequestPay);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}