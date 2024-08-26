
namespace Reservation.Application.Businesses.Commands.AddCategoriesToBusiness;



public sealed record AddCategoriesToBusinessCommandRequest(Guid BusinessId, IEnumerable<int> Categories) : IRequest
{
    public static AddCategoriesToBusinessCommandRequest Carate(Guid businessId, IEnumerable<int> categories)
        => new(businessId, categories);
}

public sealed class AddCategoriesToBusinessCommandHandler(IUnitOfWork uow) : IRequestHandler<AddCategoriesToBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(AddCategoriesToBusinessCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        foreach (var categoryId in request.Categories)
        {
            var category = await _uow.Categories.FindAsync(categoryId, cancellationToken)
                ?? throw new CategoryNotFoundException();

            business.Categories.Add(category);
        }

        await _uow.SaveChangeAsync(cancellationToken);
    }
}