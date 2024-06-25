namespace Reservation.Application.Finances.BusinessRequestPays.Commands.CreateBusinessRequestPay;

public class CreateBusinessRequestPayCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateBusinessRequestPayCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateBusinessRequestPayCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessesNotFoundException();

        BusinessRequestPay businessRequestPay = new()
        {
            Amount = request.Amount,
            Business = business
        };

        _uow.BusinessRequestPays.Add(businessRequestPay);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}