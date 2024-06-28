namespace Reservation.Application.Account.Commands.LogoutUser;


public record LogoutUserCommandRequest(Guid UserId) : IRequest;

public sealed class LogoutUserCommandHandler(IUnitOfWork uow)
    : IRequestHandler<LogoutUserCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(LogoutUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();

        user.IsActive = false;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}