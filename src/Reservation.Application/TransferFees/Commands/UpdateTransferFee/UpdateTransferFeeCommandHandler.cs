namespace Reservation.Application.TransferFees.Commands.UpdateTransferFee;

public sealed class UpdateTransferFeeCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateTransferFeeCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateTransferFeeCommandRequest request, CancellationToken cancellationToken)
    {
        var transferFee = await _uow.TransferFees.FindAsync();

        transferFee.Percent = request.Percent;
        transferFee.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}