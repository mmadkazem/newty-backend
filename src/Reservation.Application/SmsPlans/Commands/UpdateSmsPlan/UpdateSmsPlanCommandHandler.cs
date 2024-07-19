namespace Reservation.Application.SmsPlans.Commands.UpdateSmsPlan;

public sealed class UpdateSmsPlanCommandHandler(IUnitOfWork uow)
    : IRequestHandler<UpdateSmsPlanCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateSmsPlanCommandRequest request, CancellationToken cancellationToken)
    {
        SmsPlan smsPlan = await _uow.SmsPlans.FindAsync(request.Id, cancellationToken)
            ?? throw new SmsPlanNotFoundException();

        if (smsPlan.Name != request.Name && !await _uow.SmsPlans.AnyAsync(request.Name, cancellationToken))
        {
            throw new TitleAlreadyExistException();
        }

        smsPlan.Name = request.Name;
        smsPlan.Description = request.Description;
        smsPlan.SmsCount = request.Count;
        smsPlan.Price = request.Price;
        smsPlan.CoverImagePath = request.CoverImagePath;
        smsPlan.Discount = request.Discount;
        smsPlan.ModifiedOn = DateTime.Now;

        await _uow.SaveChangeAsync(cancellationToken);
    }
}