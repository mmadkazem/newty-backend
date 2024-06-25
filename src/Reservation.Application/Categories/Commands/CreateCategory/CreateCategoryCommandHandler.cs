namespace Reservation.Application.Categories.Commands.CreateCategory;


public sealed class CreateCategoryCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateCategoryCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Category category = new()
        {
            Title = request.Title,
            Description = request.Description,
            CoverImagePath = request.CoverImagePath,
        };

        _uow.Categories.Add(category);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}