namespace Reservation.Application.Businesses.Commands.AddUserVIP;


public sealed record AddUserVIPCommandRequest(Guid BusinessId, Guid UserId) : IRequest;

public sealed class AddUserVIPCommandHandler(IUnitOfWork uow) : IRequestHandler<AddUserVIPCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(AddUserVIPCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();

        UserVIP userVIP = new()
        {
            Business = business,
            User = user,
        };
        _uow.Businesses.AddUserVIP(userVIP);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}