namespace Reservation.Application.SmsPlans.Commands.CreateSmsPlan;

public sealed class CreateSmsPlanCommandHandler(IUnitOfWork uow)
    : IRequestHandler<CreateSmsPlanCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateSmsPlanCommandRequest request, CancellationToken cancellationToken)
    {
        SmsPlan smsPlan = new()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            SmsCount = request.Count,
            CoverImagePath = request.CoverImagePath,
            Discount = request.Discount
        };

        _uow.SmsPlans.Add(smsPlan);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}