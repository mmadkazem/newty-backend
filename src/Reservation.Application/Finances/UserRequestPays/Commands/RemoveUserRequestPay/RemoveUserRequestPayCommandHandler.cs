namespace Reservation.Application.Finances.UserRequestPays.Commands.RemoveUserRequestPay;

public sealed class RemoveUserRequestPayCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveUserRequestPayCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemoveUserRequestPayCommandRequest request, CancellationToken cancellationToken)
    {
        var userRequestPay = await _uow.UserRequestPays.FindAsync(request.Id, cancellationToken)
            ?? throw new UserRequestPayNotFoundException();

        if (userRequestPay.UserId != request.UserId)
        {
            throw new DoNotAccessToRemoveItemException("درخواست پرداخت");
        }

        _uow.UserRequestPays.Remove(userRequestPay);
    }
}