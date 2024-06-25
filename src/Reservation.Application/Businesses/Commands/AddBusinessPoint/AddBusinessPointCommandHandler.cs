namespace Reservation.Application.Businesses.Commands.AddBusinessPoint;

public sealed class AddBusinessPointCommandHandler(IUnitOfWork uow)
    : IRequestHandler<AddBusinessPointCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(AddBusinessPointCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();

        var business = await _uow.Businesses.FindAsyncByIncludePoints(request.BusinessId, cancellationToken)
            ?? throw new BusinessesNotFoundException();

        business.Average = await _uow.Businesses.GetAveragePoints(request.BusinessId, cancellationToken);

        Point point = new()
        {
            Rate = request.Rate,
            User = user
        };

        business.Points.Add(point);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}