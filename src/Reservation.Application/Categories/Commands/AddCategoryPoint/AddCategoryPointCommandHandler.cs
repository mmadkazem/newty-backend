
namespace Reservation.Application.Categories.Commands.AddCategoryPoint;

public class AddCategoryPointCommandHandler(IUnitOfWork uow)
    : IRequestHandler<AddCategoryPointCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(AddCategoryPointCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();

        var category = await _uow.Categories.FindAsyncByIncludePoints(request.CategoryId, cancellationToken)
            ?? throw new CategoryNotFoundException();

        category.AveragePoint = await _uow.Categories.GetAveragePoints(request.CategoryId, cancellationToken);

        Point point = new()
        {
            Rate = request.Rate,
            User = user
        };

        category.Points.Add(point);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}