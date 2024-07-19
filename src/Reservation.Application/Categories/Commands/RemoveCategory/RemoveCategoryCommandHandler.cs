namespace Reservation.Application.Categories.Commands.RemoveCategory;

public sealed class RemoveCategoryCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveCategoryCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await _uow.Categories.FindAsync(request.Id, cancellationToken)
            ?? throw new CategoryNotFoundException();

        _uow.Categories.Remove(category);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}