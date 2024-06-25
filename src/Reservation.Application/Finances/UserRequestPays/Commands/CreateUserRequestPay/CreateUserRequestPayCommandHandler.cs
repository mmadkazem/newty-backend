namespace Reservation.Application.Finances.UserRequestPays.Commands.CreateUserRequestPay;

public sealed class CreateUserRequestPayCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateUserRequestPayCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateUserRequestPayCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();

        UserRequestPay userRequestPay = new()
        {
            Amount = request.Amount,
            User = user,
        };

        _uow.UserRequestPays.Add(userRequestPay);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}