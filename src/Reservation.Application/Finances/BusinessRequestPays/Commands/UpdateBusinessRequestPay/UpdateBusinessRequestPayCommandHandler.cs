namespace Reservation.Application.Finances.BusinessRequestPays.Commands.UpdateBusinessRequestPay;

public sealed class UpdateBusinessRequestPayCommandHandler(IUnitOfWork uow)
    : IRequestHandler<UpdateBusinessRequestPayCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateBusinessRequestPayCommandRequest request, CancellationToken cancellationToken)
    {
        var businessRequestPay = await _uow.BusinessRequestPays.FindAsync(request.Id, cancellationToken)
            ?? throw new BusinessRequestPayNotFoundException();

        businessRequestPay.IsPay = request.IsPay;
        businessRequestPay.Authorizy = request.Authorizy;
        businessRequestPay.RefId = request.RefId;
        businessRequestPay.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}