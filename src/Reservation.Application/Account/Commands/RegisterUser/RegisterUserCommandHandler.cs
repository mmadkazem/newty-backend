namespace Reservation.Application.Account.Commands.RegisterUser;


public sealed class RegisterUserCommandHandler(IUnitOfWork uow)
    : IRequestHandler<RegisterUserCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FullName = request.FullName,
            PhoneNumber = request.PhoneNumber
        };

        _uow.Users.Add(user);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}