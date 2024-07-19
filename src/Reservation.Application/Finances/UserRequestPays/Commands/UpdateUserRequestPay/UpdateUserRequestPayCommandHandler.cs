namespace Reservation.Application.Finances.UserRequestPays.Commands.UpdateUserRequestPay;

public sealed class UpdateUserRequestPayCommandHandler(IUnitOfWork uow)
    : IRequestHandler<UpdateUserRequestPayCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateUserRequestPayCommandRequest request, CancellationToken cancellationToken)
    {
        var userRequestPay = await _uow.UserRequestPays.FindAsync(request.Id, cancellationToken)
            ?? throw new UserRequestPayNotFoundException();

        if (userRequestPay.UserId != request.UserId)
        {
            throw new DoNotAccessToRemoveItemException("درخواست پرداخت");
        }

        userRequestPay.IsPay = request.IsPay;
        userRequestPay.Authorizy = request.Authorizy;
        userRequestPay.RefId = request.RefId;
        userRequestPay.PayDate = DateTime.Now;
        userRequestPay.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}