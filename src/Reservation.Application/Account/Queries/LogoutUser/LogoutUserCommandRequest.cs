namespace Reservation.Application.Account.Queries.LogoutUser;


public record LogoutQueryRequest(Guid Id) : IRequest;

public sealed class LogoutQueryHandler(IUnitOfWork uow)
    : IRequestHandler<LogoutQueryRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(LogoutQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.Id, cancellationToken);
        if (user is not null)
        {
            user.IsActive = false;
            await _uow.SaveChangeAsync(cancellationToken);
            return;
        }

        var business = await _uow.Businesses.FindAsync(request.Id, cancellationToken);
        if (business is not null)
        {
            business.IsActive = false;
            await _uow.SaveChangeAsync(cancellationToken);
            return;
        }

        throw new UserNotFoundException();
    }
}