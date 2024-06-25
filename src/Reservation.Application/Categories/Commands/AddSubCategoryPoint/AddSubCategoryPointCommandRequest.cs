namespace Reservation.Application.Categories.Commands.AddSubCategoryPoint;


public record AddSubCategoryPointCommandRequest(Guid SubCategoryId, Guid UserId, int Rate) : IRequest
{
    public static AddSubCategoryPointCommandRequest Create(Guid userId, AddSubCategoryPointDTO model)
        => new(userId, model.SubCategoryId, model.Rate);
}

public record AddSubCategoryPointDTO(Guid SubCategoryId, int Rate);


public sealed class AddSubCategoryPointCommandHandler(IUnitOfWork uow) : IRequestHandler<AddSubCategoryPointCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(AddSubCategoryPointCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();

        var subCategory = await _uow.Categories.FindAsyncSubCategoryByIncludePoints(request.SubCategoryId, cancellationToken)
            ?? throw new CategoryNotFoundException();

        subCategory.AveragePoint = await _uow.Categories.GetSubCategoryAveragePoints(request.SubCategoryId, cancellationToken);

        Point point = new()
        {
            Rate = request.Rate,
            User = user
        };

        subCategory.Points.Add(point);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}