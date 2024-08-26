
namespace Reservation.Application.Account.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateUserCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.Id, cancellationToken)
            ?? throw new UserNotFoundException();

        var city = await _uow.Cities.FindAsyncByName(request.City, cancellationToken)
            ?? throw new CityNotFoundException();

        user.FullName = request.FullName;
        user.City = city;
        user.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}